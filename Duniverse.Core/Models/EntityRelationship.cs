namespace Duniverse.Models
{
    /// <summary>
    /// A single labeled connection between two entities, read in both directions. FromRole says
    /// what From is to To; ToRole says what To is to From. For (Jessica, Paul), FromRole is
    /// "Mother" and ToRole is "Son". Symmetric relationships (rivals, twins) simply carry the
    /// same phrase on both sides.
    ///
    /// Tier guards the label itself, separately from the entities it connects. Both Alia and the
    /// Baron appear in Dune, but "Possessed by his ego-memory" gives away Children of Dune, so
    /// that label carries the later tier and stays hidden from readers who haven't gotten there,
    /// even though the connection itself still shows.
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
