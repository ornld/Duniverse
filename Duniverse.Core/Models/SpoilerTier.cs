namespace Duniverse.Models
{
    /// <summary>
    /// How far into the saga an entity is safe to meet, which drives the optional spoiler gate.
    /// The six novels climb in order, so a reader partway through sees everything below them. I
    /// keep ExpandedUniverse outside that spine on purpose.
    /// </summary>
    public enum SpoilerTier
    {
        /// <summary>Introduced in, or safely known from, Dune (1965). The default for every entity.</summary>
        Dune = 1,

        /// <summary>First revealed in Dune Messiah (1969).</summary>
        DuneMessiah = 2,

        /// <summary>First revealed in Children of Dune (1976).</summary>
        ChildrenOfDune = 3,

        /// <summary>First revealed in God Emperor of Dune (1981).</summary>
        GodEmperorOfDune = 4,

        /// <summary>First revealed in Heretics of Dune (1984).</summary>
        HereticsOfDune = 5,

        /// <summary>First revealed in Chapterhouse: Dune (1985).</summary>
        Chapterhouse = 6,

        /// <summary>
        /// Appears only in the Expanded Universe prequels and sequels. Gated by its own toggle,
        /// so its numeric value stays outside the six-novel spine on purpose.
        /// </summary>
        ExpandedUniverse = 100
    }
}
