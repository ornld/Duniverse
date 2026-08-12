namespace Duniverse.Models
{
    /// <summary>
    /// One entry in the Collected Sayings archive, credited the way Frank Herbert headed his
    /// chapters. Work doubles as the grouping key, so everything from one source gathers under a
    /// heading. I store Text verbatim so verse renders through pre-line whitespace.
    /// </summary>
    public class Epigraph
    {
        /// <summary>The quotation itself, verbatim.</summary>
        public required string Text { get; init; }

        /// <summary>
        /// The in-universe attribution ("Manual of Muad'Dib, by the Princess Irulan"), used
        /// both as the credit line and the grouping header.
        /// </summary>
        public required string Work { get; init; }

        /// <summary>
        /// The earliest book by which the saying is safe to read, mirroring the entity spoiler
        /// gate. Defaults to Dune, meaning never hidden.
        /// </summary>
        public SpoilerTier Tier { get; init; } = SpoilerTier.Dune;
    }
}
