using Duniverse.Data;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Tests
{
    /// <summary>
    /// The structural promises of the archive. The debug validators cover most of these at
    /// startup, and these tests keep the same promises standing in a Release build.
    /// </summary>
    [Collection("archive")]
    public sealed class ArchiveIntegrityTests
    {
        private readonly EntityRegistry _registry;

        public ArchiveIntegrityTests(ArchiveFixture fixture) => _registry = fixture.Registry;

        [Fact]
        public void EveryRelatedIdResolves()
        {
            // A dangling id never renders, so nothing in the app notices one. This does.
            var dangling = _registry.GetAllEntities<DuneEntity>()
                .SelectMany(entity => entity.RelatedEntityIds
                    .Where(id => _registry.GetEntity(id) is null)
                    .Select(id => $"{entity.Id} -> {id}"))
                .ToList();

            Assert.Empty(dangling);
        }

        [Fact]
        public void EverySpoilerTierIdResolves()
        {
            var unknown = SpoilerTierMap.Tiers.Keys
                .Where(id => _registry.GetEntity(id) is null)
                .ToList();

            Assert.Empty(unknown);
        }

        [Fact]
        public void EveryRelationshipEndpointResolves()
        {
            var unknown = RelationshipMap.Relationships
                .SelectMany(rel => new[] { rel.FromId, rel.ToId })
                .Where(id => _registry.GetEntity(id) is null)
                .Distinct()
                .ToList();

            Assert.Empty(unknown);
        }

        [Fact]
        public void EveryFiefIdResolvesAndEveryLineHoldsAnEra()
        {
            foreach (var line in FiefMap.Lines)
            {
                Assert.NotNull(_registry.GetEntity(line.WorldId));
                Assert.NotEmpty(line.Eras);

                foreach (var later in line.LaterNames)
                {
                    Assert.NotNull(_registry.GetEntity(later));
                }

                foreach (var era in line.Eras.Where(era => era.HolderId is not null))
                {
                    Assert.NotNull(_registry.GetEntity(era.HolderId!));
                }
            }
        }
    }
}
