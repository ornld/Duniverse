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
    /// Remembers which of a record's later passages the reader has already been shown, so the
    /// site can tell the difference between a passage that is merely there and one that has
    /// just opened.
    ///
    /// The spoiler tiers make the archive grow as the reader reads, and until now that growth
    /// was silent: finish a book, come back to a record, and it is simply longer, with nothing
    /// marking the moment. This is the ledger that lets the moment be marked once.
    ///
    /// The important case is the first sight of any record. A reader landing on an entry for
    /// the first time has not unlocked anything, they have just arrived, so whatever is visible
    /// then is written down without ceremony. Only a passage that appears on a LATER visit,
    /// because the reader moved their progress in between, counts as newly opened. Storing per
    /// record rather than per tier is what makes that distinction possible: an absent record
    /// means never seen, an empty list means seen while holding nothing.
    ///
    /// Losing this ledger costs a reader nothing but a small moment, so every failure path
    /// simply behaves as though everything has already been witnessed.
    /// </summary>
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
        /// Which of the currently visible layers the reader has not been shown before, and so
        /// deserve to be marked as newly opened. Empty on a record this reader has never
        /// opened, because arriving somewhere for the first time is not the same as unlocking
        /// it.
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
