using Duniverse.Models;
using Duniverse.Web.Services;
using Microsoft.JSInterop;

namespace Duniverse.Tests
{
    /// <summary>
    /// The stored-state parser once read an empty object as protection off and unsealed
    /// the whole archive. Every fallback has to seal, and these hold it to that.
    /// </summary>
    public sealed class SpoilerSettingsTests
    {
        // A browser with one stored value and nothing else. Writes land in SavedRaw so a
        // test can look at what would have been persisted.
        private sealed class FakeStorage : IJSRuntime
        {
            private readonly string? _raw;

            public FakeStorage(string? raw) => _raw = raw;

            public string? SavedRaw { get; private set; }

            public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args) =>
                InvokeAsync<TValue>(identifier, CancellationToken.None, args);

            public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
            {
                if (identifier == "localStorage.setItem")
                {
                    SavedRaw = args?[1] as string;
                }

                var result = identifier == "localStorage.getItem" ? _raw : null;
                return ValueTask.FromResult((TValue)(object?)result!);
            }
        }

        private static async Task<SpoilerSettings> LoadedFrom(string? raw)
        {
            var settings = new SpoilerSettings(new FakeStorage(raw));
            await settings.LoadAsync();
            return settings;
        }

        [Fact]
        public async Task AnEmptyObjectSealsTheArchive()
        {
            var settings = await LoadedFrom("{}");

            Assert.True(settings.Enabled);
            Assert.Equal(SpoilerTier.Dune, settings.NovelProgress);
            Assert.False(settings.IncludeExpandedUniverse);
        }

        [Fact]
        public async Task ProgressPastTheSixNovelsFallsBackToBookOne()
        {
            var settings = await LoadedFrom("{\"Enabled\":true,\"NovelProgress\":99,\"IncludeExpandedUniverse\":false}");

            Assert.Equal(SpoilerTier.Dune, settings.NovelProgress);
        }

        [Fact]
        public async Task AWholeStoredChoiceIsHonored()
        {
            var settings = await LoadedFrom("{\"Enabled\":true,\"NovelProgress\":5,\"IncludeExpandedUniverse\":true}");

            Assert.True(settings.Enabled);
            Assert.Equal(SpoilerTier.HereticsOfDune, settings.NovelProgress);
            Assert.True(settings.IncludeExpandedUniverse);
            Assert.True(settings.HasStoredChoice);
        }

        [Fact]
        public async Task GarbageFallsBackSealedAndStillLoads()
        {
            var settings = await LoadedFrom("not json at all");

            Assert.True(settings.Loaded);
            Assert.True(settings.Enabled);
            Assert.Equal(SpoilerTier.Dune, settings.NovelProgress);
        }

        [Fact]
        public async Task NothingStoredMeansNoChoiceYet()
        {
            var settings = await LoadedFrom(null);

            Assert.True(settings.Loaded);
            Assert.False(settings.HasStoredChoice);
        }

        [Fact]
        public async Task ExpandedUniverseAnswersToItsOwnToggle()
        {
            var reading = await LoadedFrom("{\"Enabled\":true,\"NovelProgress\":6,\"IncludeExpandedUniverse\":false}");

            Assert.True(reading.IsVisible(SpoilerTier.Chapterhouse));
            Assert.False(reading.IsVisible(SpoilerTier.ExpandedUniverse));
        }
    }
}
