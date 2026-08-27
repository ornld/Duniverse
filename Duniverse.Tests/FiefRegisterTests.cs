using Duniverse.Data;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Tests
{
    /// <summary>
    /// The census the Siridar Register promises at each reading position, held as numbers
    /// instead of screenshots. These were hand-measured once; now they stay measured.
    /// </summary>
    [Collection("archive")]
    public sealed class FiefRegisterTests
    {
        private readonly EntityRegistry _registry;

        public FiefRegisterTests(ArchiveFixture fixture) => _registry = fixture.Registry;

        private int WorldsHeldBy(string holderId, Func<SpoilerTier, bool> reader) =>
            FiefMap.Lines.Count(line =>
                _registry.GetEntity(line.WorldId) is { } world && reader(world.SpoilerTier)
                && FiefMap.CurrentEra(line, reader)?.HolderId is { } id
                && string.Equals(id, holderId, StringComparison.OrdinalIgnoreCase));

        [Fact]
        public void TheSisterhoodGrowsFromOneWorldToFour()
        {
            Assert.Equal(1, WorldsHeldBy("org_BeneGesserit", ArchiveFixture.ReaderAt(SpoilerTier.Dune)));
            Assert.Equal(4, WorldsHeldBy("org_BeneGesserit", ArchiveFixture.ReaderAt(SpoilerTier.HereticsOfDune)));
        }

        [Fact]
        public void TheHarkonnensVanishFromTheCensusByHeretics()
        {
            Assert.Equal(1, WorldsHeldBy("house_Harkonnen", ArchiveFixture.ReaderAt(SpoilerTier.Dune)));
            Assert.Equal(0, WorldsHeldBy("house_Harkonnen", ArchiveFixture.ReaderAt(SpoilerTier.HereticsOfDune)));
        }

        [Fact]
        public void PrequelErasNeverBecomeTheCurrentHolder()
        {
            // Eras run in story order and the register shows the last visible one, so a
            // prequel entry must sit early. Arrakis proves it: prequels on, Richese joins
            // the chain, the Atreides still hold the world.
            var line = FiefMap.LineFor("loc_Arrakis")!;
            var reader = ArchiveFixture.ReaderAt(SpoilerTier.Dune, expanded: true);

            Assert.Contains(FiefMap.VisibleEras(line, reader), era => era.HolderId == "house_Richese");
            Assert.Equal("house_Atreides", FiefMap.CurrentEra(line, reader)!.HolderId);
        }

        [Fact]
        public void TheIxianVeilYieldsToThePrequels()
        {
            var line = FiefMap.LineFor("loc_Ix")!;

            var veiled = FiefMap.CurrentEra(line, ArchiveFixture.ReaderAt(SpoilerTier.Dune))!;
            Assert.Null(veiled.HolderId);

            var named = FiefMap.CurrentEra(line, ArchiveFixture.ReaderAt(SpoilerTier.Dune, expanded: true))!;
            Assert.Equal("house_Vernius", named.HolderId);
        }

        [Fact]
        public void EveryVisibleWorldHasAHolderAtBookOne()
        {
            var reader = ArchiveFixture.ReaderAt(SpoilerTier.Dune);

            foreach (var line in FiefMap.Lines)
            {
                var world = _registry.GetEntity(line.WorldId)!;
                if (reader(world.SpoilerTier))
                {
                    Assert.NotNull(FiefMap.CurrentEra(line, reader));
                }
            }
        }
    }
}
