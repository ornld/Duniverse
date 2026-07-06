using System;
using System.Text.Json;
using System.Threading.Tasks;
using Duniverse.Models;
using Microsoft.JSInterop;

namespace Duniverse.Web.Services
{
    /// <summary>
    /// Holds the reader's optional spoiler-protection preferences and decides whether a given
    /// entity should currently be shown. The settings live in the browser's localStorage, so a
    /// choice sticks across reloads and return visits.
    ///
    /// Protection is opt-in. Until the reader turns it on, <see cref="IsVisible(SpoilerTier)"/>
    /// returns true for everything, so casual visitors and search-engine arrivals always see the
    /// full site. Once it is on, an entity is shown only if the reader has read far enough along
    /// the six-novel spine, or, for Expanded Universe entities, has opted into those as well.
    /// </summary>
    public class SpoilerSettings
    {
        private const string StorageKey = "duniverse.spoiler.v1";
        private readonly IJSRuntime _js;

        public SpoilerSettings(IJSRuntime js) => _js = js;

        /// <summary>Whether the reader has turned spoiler protection on at all.</summary>
        public bool Enabled { get; private set; }

        /// <summary>
        /// How far the reader has read the six-novel spine, as the furthest safe tier
        /// (Dune through Chapterhouse). Only meaningful when <see cref="Enabled"/> is true.
        /// </summary>
        public SpoilerTier NovelProgress { get; private set; } = SpoilerTier.Dune;

        /// <summary>Whether the reader wants Expanded Universe entities revealed too.</summary>
        public bool IncludeExpandedUniverse { get; private set; }

        /// <summary>True once the initial read from localStorage has completed.</summary>
        public bool Loaded { get; private set; }

        /// <summary>
        /// Reads any saved preferences out of localStorage. Idempotent: the first call does the
        /// work, later calls return immediately, so every page can safely await it on init.
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
                    var stored = JsonSerializer.Deserialize<StoredState>(raw);
                    if (stored is not null)
                    {
                        Enabled = stored.Enabled;
                        NovelProgress = stored.NovelProgress;
                        IncludeExpandedUniverse = stored.IncludeExpandedUniverse;
                    }
                }
            }
            catch
            {
                // localStorage can be blocked (private mode, strict privacy settings). Falling
                // back to defaults just means protection stays off, which is the safe default.
            }

            Loaded = true;
        }

        /// <summary>
        /// Applies a new set of preferences and saves them to localStorage. Pages that need to
        /// re-filter in place listen for the OnChanged callback on SpoilerControl instead.
        /// </summary>
        public async Task UpdateAsync(bool enabled, SpoilerTier novelProgress, bool includeExpandedUniverse)
        {
            Enabled = enabled;
            NovelProgress = novelProgress;
            IncludeExpandedUniverse = includeExpandedUniverse;

            try
            {
                var raw = JsonSerializer.Serialize(new StoredState(Enabled, NovelProgress, IncludeExpandedUniverse));
                await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, raw);
            }
            catch
            {
                // If persistence fails the in-memory settings still apply for this session.
            }
        }

        /// <summary>Whether an entity of the given tier should currently be shown to the reader.</summary>
        public bool IsVisible(SpoilerTier tier)
        {
            if (!Enabled)
            {
                return true;
            }

            if (tier == SpoilerTier.ExpandedUniverse)
            {
                return IncludeExpandedUniverse;
            }

            return tier <= NovelProgress;
        }

        /// <summary>Whether the given entity should currently be shown to the reader.</summary>
        public bool IsVisible(DuneEntity entity) => IsVisible(entity.SpoilerTier);

        private record StoredState(bool Enabled, SpoilerTier NovelProgress, bool IncludeExpandedUniverse);
    }
}
