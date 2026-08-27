using Duniverse.Data;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Tests
{
    /// <summary>
    /// The site's first promise: nothing a reader can see names a record they have not
    /// earned. The guard scans here in every configuration, and the labels carrying a
    /// later book than their endpoints stay pinned.
    /// </summary>
    [Collection("archive")]
    public sealed class SpoilerLeakTests
    {
        private readonly EntityRegistry _registry;

        public SpoilerLeakTests(ArchiveFixture fixture) => _registry = fixture.Registry;

        [Fact]
        public void ProseNamesNoSealedRecord()
        {
            Assert.Empty(SpoilerProseGuard.FindBreaches(_registry));
        }

        // The endpoint rule fails the same way each time: two book-one records joined by
        // a later fact. The guard cannot catch narrated facts, so each known case pins
        // here, and a new one joins the day it is written.
        [Theory]
        [InlineData("org_BeneTleilax", "char_DuncanIdaho")]
        [InlineData("char_Stilgar", "char_GaiusHelenMohiam")]
        [InlineData("char_Stilgar", "char_Edric")]
        [InlineData("char_GaiusHelenMohiam", "char_PrincessIrulan")]
        public void LaterBookFactsKeepTheirTier(string oneId, string otherId)
        {
            var label = _registry.GetRelationshipLabel(oneId, otherId);

            Assert.NotNull(label);
            Assert.True(label!.Value.Tier >= SpoilerTier.DuneMessiah,
                $"The label joining {oneId} and {otherId} tells a later book's fact and must not open at book one.");
        }

        [Fact]
        public void InventedLinksStaySealedUntilTheirBook()
        {
            // Alia and Duncan marry in the third book, and the map invented that edge. At
            // book one the bare line is itself the spoiler, so the connection has to hide.
            var atBookOne = _registry
                .GetDirectlyRelated("char_AliaAtreides", ArchiveFixture.ReaderAt(SpoilerTier.Dune))
                .Select(entity => entity.Id);
            var atChildren = _registry
                .GetDirectlyRelated("char_AliaAtreides", ArchiveFixture.ReaderAt(SpoilerTier.ChildrenOfDune))
                .Select(entity => entity.Id);

            Assert.DoesNotContain("char_DuncanIdaho", atBookOne, StringComparer.OrdinalIgnoreCase);
            Assert.Contains("char_DuncanIdaho", atChildren, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void HeldBackLayersStayOutOfContentSearch()
        {
            // Korba's priesthood lives in his second-book layer. A search on its wording
            // must not surface him for a reader still at book one.
            var atBookOne = _registry
                .SearchByContent("panegyrist", ArchiveFixture.ReaderAt(SpoilerTier.Dune))
                .Select(entity => entity.Id);
            var atMessiah = _registry
                .SearchByContent("panegyrist", ArchiveFixture.ReaderAt(SpoilerTier.DuneMessiah))
                .Select(entity => entity.Id);

            Assert.DoesNotContain("char_Korba", atBookOne, StringComparer.OrdinalIgnoreCase);
            Assert.Contains("char_Korba", atMessiah, StringComparer.OrdinalIgnoreCase);
        }
    }
}
