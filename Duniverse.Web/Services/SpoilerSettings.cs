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
    /// Protection is on by default: a first-time visitor starts at Dune, the first book, and
    /// owns their settings from there. Anyone who has made a choice keeps it, since saved
    /// preferences always win over the default; turning protection off entirely opens the whole
    /// site. When it is on, an entity is shown only if the reader has read far enough along the
    /// six-novel spine, or, for Expanded Universe entities, has opted into those as well.
    /// </summary>
    public class SpoilerSettings
    {
        private const string StorageKey = "duniverse.spoiler.v1";
        private readonly IJSRuntime _js;

        public SpoilerSettings(IJSRuntime js) => _js = js;

        /// <summary>
        /// Whether spoiler protection is active. True from the first visit, paired with the
        /// Dune default on <see cref="NovelProgress"/>, so a newcomer starts safe at book one
        /// and widens the gate themselves as they read.
        /// </summary>
        public bool Enabled { get; private set; } = true;

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
        /// True once the reader owns their settings: a saved preference was found in
        /// localStorage, or they made a choice this session. False on a genuine first visit,
        /// which is what cues the one-time clearance ritual in the layout.
        /// </summary>
        public bool HasStoredChoice { get; private set; }

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
                        HasStoredChoice = true;
                    }
                }
            }
            catch
            {
                // localStorage can be blocked (private mode, strict privacy settings). Falling
                // back to defaults means protection stays on at Dune, the safe starting point.
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

            // Even if persistence fails below, the reader has decided; the ritual must not
            // come back mid-session to ask again.
            HasStoredChoice = true;

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
