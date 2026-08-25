namespace Duniverse.Models
{
    /// <summary>
    /// One entry in the Collected Sayings archive, credited the way Frank Herbert headed his
    /// chapters. Tier doubles as the book, so each novel's page pulls its own run in reading
    /// order. I store Text verbatim so verse renders through pre-line whitespace.
    /// </summary>
    public class Epigraph
    {
        /// <summary>The quotation itself, verbatim.</summary>
        public required string Text { get; init; }

        /// <summary>
        /// The in-universe attribution ("Manual of Muad'Dib, by the Princess Irulan"), the
        /// credit line under the quote and the heading over a spoken group.
        /// </summary>
        public required string Work { get; init; }

        /// <summary>
        /// The book the heading is printed in, which is also the earliest book by which it is
        /// safe to read. Defaults to Dune, meaning never hidden.
        /// </summary>
        public SpoilerTier Tier { get; init; } = SpoilerTier.Dune;

        /// <summary>
        /// True for a line spoken in the story rather than printed over a chapter. The book
        /// pages hold chapter headings; a spoken line stands in its own small group.
        /// </summary>
        public bool Spoken { get; init; }
    }
}
