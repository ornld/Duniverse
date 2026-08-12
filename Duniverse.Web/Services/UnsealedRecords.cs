using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Duniverse.Models;
using Microsoft.JSInterop;

namespace Duniverse.Web.Services
{
    /// <summary>
    /// I track which tiers a record has shown a reader, so a passage that opens on a later
    /// visit gets marked. Failures act as already witnessed.
    /// </summary>
    /// <remarks>
    /// I key the ledger per record, not per tier, since that is what separates an absent
    /// record, meaning never seen, from an empty list, meaning seen with nothing open.
    /// </remarks>
    public class UnsealedRecords
    {
        private const string StorageKey = "duniverse.unsealed.v1";
        private readonly IJSRuntime _js;

        // entity id -> the layer tiers that entity has already shown this reader.
        private Dictionary<string, List<SpoilerTier>> _witnessed = new();

        public UnsealedRecords(IJSRuntime js) => _js = js;

        /// <summary>True once the ledger has been read back from the browser.</summary>
        public bool Loaded { get; private set; }

        /// <summary>
        /// Reads the ledger out of localStorage. Idempotent, and safe to await from any page
        /// that needs it.
        /// </summary>
        public async Task LoadAsync()
        {
            if (Loaded)
            {
                return;
            }

            try
            {
                var raw = await _js.InvokeAsync<string?>("localStorage.getItem", StorageKey);
                if (!string.IsNullOrEmpty(raw))
                {
                    _witnessed = JsonSerializer.Deserialize<Dictionary<string, List<SpoilerTier>>>(raw)
                                 ?? new Dictionary<string, List<SpoilerTier>>();
                }
            }
            catch
            {
                // Blocked or unreadable storage just means no ceremony, which is the quiet
                // outcome rather than the broken one.
            }

            Loaded = true;
        }

        /// <summary>
        /// Visible layers I haven't shown this reader yet, so the page can mark them as newly
        /// opened. Empty on a record this reader has never opened, since arriving for the
        /// first time isn't the same as unlocking.
        /// </summary>
        public IReadOnlyList<SpoilerTier> NewlyOpened(string entityId, IEnumerable<SpoilerTier> visible)
        {
            if (!_witnessed.TryGetValue(entityId, out var already))
            {
                return Array.Empty<SpoilerTier>();
            }

            return visible.Where(tier => !already.Contains(tier)).ToList();
        }

        /// <summary>
        /// Writes down everything the record is showing right now, so none of it is announced
        /// again. Called on every visit, including the first, which is what seeds a record
        /// without ceremony.
        /// </summary>
        public async Task WitnessAsync(string entityId, IEnumerable<SpoilerTier> visible)
        {
            var tiers = visible.Distinct().ToList();

            if (_witnessed.TryGetValue(entityId, out var already))
            {
                var added = tiers.Where(t => !already.Contains(t)).ToList();
                if (added.Count == 0)
                {
                    return; // nothing new to write down, so leave storage alone
                }
                already.AddRange(added);
            }
            else
            {
                _witnessed[entityId] = tiers;
            }

            try
            {
                await _js.InvokeVoidAsync("localStorage.setItem", StorageKey,
                    JsonSerializer.Serialize(_witnessed));
            }
            catch
            {
                // The in-memory ledger still holds for this session, so the ceremony will not
                // repeat while the reader is here. It may repeat on a later visit, which is a
                // far smaller cost than failing to render.
            }
        }
    }
}
