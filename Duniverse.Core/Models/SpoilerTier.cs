namespace Duniverse.Models
{
    /// <summary>
    /// The earliest work by which an entity is safe to encounter. Drives the site's optional,
    /// opt-in spoiler protection, which hides people, places, and events a reader has not
    /// reached yet.
    ///
    /// The six Frank Herbert novels form an ordered spine: each value is greater than the one
    /// before it, so a reader who has read "up to Children of Dune" safely sees everything
    /// tagged Dune, Dune Messiah, or Children of Dune. ExpandedUniverse sits deliberately
    /// outside that order. It covers entities that appear only in the Brian Herbert and Kevin
    /// J. Anderson prequels and sequels, and it is gated by its own separate toggle rather than
    /// by how far along the six-novel spine a reader has come.
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
