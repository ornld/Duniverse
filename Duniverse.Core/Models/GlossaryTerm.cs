namespace Duniverse.Models
{
    /// <summary>
    /// One entry in Terminology of the Imperium, my take on the appendix Frank Herbert bound
    /// into Dune. I kept it lighter than a DuneEntity: a term is a word worth defining, not a
    /// subject worth a record.
    /// </summary>
    public class GlossaryTerm
    {
        /// <summary>The word or phrase as a reader would look it up.</summary>
        public required string Term { get; init; }

        /// <summary>The definition, written in the crisp voice of a field dictionary.</summary>
        public required string Definition { get; init; }

        /// <summary>Optional id of the full encyclopedia record covering the same subject.</summary>
        public string? SeeEntityId { get; init; }

        /// <summary>
        /// The earliest work by which the term is safe to encounter, mirroring the entity
        /// spoiler gate. Defaults to Dune, meaning never hidden.
        /// </summary>
        public SpoilerTier Tier { get; init; } = SpoilerTier.Dune;
    }
}
