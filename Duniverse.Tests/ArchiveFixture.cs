using Duniverse.Data;
using Duniverse.Models;
using Duniverse.Services;

namespace Duniverse.Tests
{
    /// <summary>
    /// One seeded registry shared by every test class. Seeding runs the debug validators
    /// as a side effect, and building it once keeps the whole suite fast.
    /// </summary>
    public sealed class ArchiveFixture
    {
        public EntityRegistry Registry { get; } = RegistryFactory.CreateSeeded();

        /// <summary>A reader partway through the novels, with the prequels off or on.</summary>
        public static Func<SpoilerTier, bool> ReaderAt(SpoilerTier novels, bool expanded = false) =>
            tier => tier == SpoilerTier.ExpandedUniverse ? expanded : tier <= novels;
    }

    [CollectionDefinition("archive")]
    public sealed class ArchiveCollection : ICollectionFixture<ArchiveFixture>
    {
    }
}
