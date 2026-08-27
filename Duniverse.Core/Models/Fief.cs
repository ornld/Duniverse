namespace Duniverse.Models
{
    /// <summary>
    /// One stretch of a world's ownership. Tier is the book that makes it known. HolderId
    /// links a record when one exists; Holder is the printed text either way. A veiled
    /// era yields to the Expanded Universe's fuller account.
    /// </summary>
    public sealed record FiefEra(
        SpoilerTier Tier,
        string? HolderId,
        string Holder,
        string? Note = null,
        bool VeiledByExpanded = false);

    /// <summary>
    /// One world's row in the register: its record, the later names it answers to
    /// (Rakis for Arrakis), and its holders in the order they held it.
    /// </summary>
    public sealed record FiefLine(
        string WorldId,
        IReadOnlyList<string> LaterNames,
        IReadOnlyList<FiefEra> Eras);
}
