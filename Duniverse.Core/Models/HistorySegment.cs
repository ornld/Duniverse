namespace Duniverse.Models
{
    /// <summary>
    /// One later chapter of a record's story, held back until the reader reaches its book. The
    /// gate picks which records open, never the words inside. Write each segment to read as a
    /// finished ending, not a cut.
    /// </summary>
    /// <param name="Tier">The book by which this part of the story is safe to read.</param>
    /// <param name="Text">The paragraph itself, in the same voice as the rest of the entry.</param>
    public record HistorySegment(SpoilerTier Tier, string Text);
}
