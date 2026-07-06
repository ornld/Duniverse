namespace Duniverse.Models
{
    /// <summary>
    /// One person in the great bloodline chart. Generation is the row (0 at the top, growing
    /// downward through time) and Column the hand-placed horizontal position from 0 to 1,
    /// designed so the Atreides and Harkonnen lines visibly converge on Paul.
    ///
    /// Fill names the lineage coloring the node's body: the blood in their veins. Ring names
    /// the lineage they stand with, when the two differ. Lady Jessica wears a Harkonnen fill
    /// inside an Atreides ring; that one node is the secret of the whole breeding program.
    ///
    /// Tier gates the node beyond its entity's own spoiler tier, for people whose presence in
    /// the tree is itself a later-book fact (Duncan Idaho appears in Dune, but he stands in
    /// this chart only as Alia's husband, a Children of Dune development).
    /// </summary>
    public sealed record BloodlineNode(
        string EntityId,
        int Generation,
        double Column,
        string Fill,
        string? Ring = null,
        SpoilerTier Tier = SpoilerTier.Dune);

    /// <summary>
    /// A pairing between two people in the same generation: marriage, concubinage, or a
    /// breeding-program match. Dashed marks a bond in name rather than in truth, and the
    /// Label carries the nuance for the hover ("Marriage in name alone"). Tier hides the
    /// union itself when the bond is a later-book fact, even if both partners are visible.
    /// </summary>
    public sealed record BloodlineUnion(
        string PartnerAId,
        string PartnerBId,
        string? Label = null,
        bool Dashed = false,
        SpoilerTier Tier = SpoilerTier.Dune);

    /// <summary>
    /// A line of descent to a child one generation down. With both parents given, the line
    /// drops from the midpoint of their union; with one, from that parent alone. Dashed marks
    /// indirect or long-spanning descent (the Baron's nephews, the God Emperor's millennia of
    /// quiet breeding), with Label explaining it on hover.
    /// </summary>
    public sealed record BloodlineDescent(
        string ChildId,
        string ParentAId,
        string? ParentBId = null,
        string? Label = null,
        bool Dashed = false);

    /// <summary>
    /// A horizontal break between generations standing for a span of time the chart does not
    /// draw person by person. Rendered as a labeled divider before the given generation, and
    /// only when visible people exist on both sides of it, so a gated era never advertises
    /// itself.
    /// </summary>
    public sealed record BloodlineBand(int BeforeGeneration, string Label);
}
