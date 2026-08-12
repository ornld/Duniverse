namespace Duniverse.Models
{
    /// <summary>
    /// One labeled connection, read both ways. FromRole says what From is to To, ToRole the
    /// reverse: for (Jessica, Paul) that's "Mother" and "Son". Tier guards the label separately,
    /// so a spoiler phrase can hide while the connection still shows.
    /// </summary>
    public sealed record EntityRelationship(
        string FromId,
        string ToId,
        string FromRole,
        string ToRole,
        SpoilerTier Tier = SpoilerTier.Dune);

    /// <summary>
    /// A resolved label for one direction of a relationship: the role phrase describing the
    /// other entity relative to the one being viewed, plus the tier that decides whether the
    /// reader should see it yet.
    /// </summary>
    public readonly record struct RelationshipLabel(string Role, SpoilerTier Tier);
}
