namespace Duniverse.Models
{
    /// <summary>
    /// One person in the bloodline chart. Generation is the row, Column I placed by hand so
    /// Atreides and Harkonnen converge on Paul. Fill is their blood, Ring the line they stand
    /// with, Tier gates anyone who's a later reveal.
    /// </summary>
    public sealed record BloodlineNode(
        string EntityId,
        int Generation,
        double Column,
        string Fill,
        string? Ring = null,
        SpoilerTier Tier = SpoilerTier.Dune);

    /// <summary>
    /// A same-generation pairing: marriage, concubinage, or a breeding-program match. Dashed
    /// means a bond in name only, and Label carries the nuance on hover. Tier hides a union
    /// whose bond is a later reveal, even when both partners are visible.
    /// </summary>
    public sealed record BloodlineUnion(
        string PartnerAId,
        string PartnerBId,
        string? Label = null,
        bool Dashed = false,
        SpoilerTier Tier = SpoilerTier.Dune);

    /// <summary>
    /// A line down to a child in the next generation. Two parents and it drops from the midpoint
    /// of their union, one parent and it drops from them. Dashed covers indirect or long-spanning
    /// descent, with Label explaining it on hover.
    /// </summary>
    public sealed record BloodlineDescent(
        string ChildId,
        string ParentAId,
        string? ParentBId = null,
        string? Label = null,
        bool Dashed = false);

    /// <summary>
    /// A break between generations standing in for time the chart doesn't draw person by person.
    /// It's a labeled divider, and I only draw it when visible people sit on both sides, so a
    /// gated era never advertises itself.
    /// </summary>
    public sealed record BloodlineBand(int BeforeGeneration, string Label);
}
