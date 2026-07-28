namespace Duniverse.Models
{
    /// <summary>
    /// One later chapter of a record's story, held back until the reader has read the book it
    /// comes from.
    ///
    /// The spoiler gate decides which records a reader can open. It has never had any say over
    /// the words inside a record it let them into, and for anyone who lives across several
    /// novels that gap is the whole problem: Alia belongs to Dune, so a first-time reader meets
    /// her legitimately, and one paragraph later learns how she ends. Splitting the story into
    /// tiers closes it without flattening every entry down to what book one knows.
    ///
    /// A record's own <see cref="DuneEntity.DetailedHistory"/> stays what it always was, the
    /// part that is safe the moment you can see the record at all. Each segment here carries
    /// the book that earns it. Write every one to read as finished prose on its own: a reader
    /// who stops at the first should feel they reached an ending, not a cut.
    /// </summary>
    /// <param name="Tier">The book by which this part of the story is safe to read.</param>
    /// <param name="Text">The paragraph itself, in the same voice as the rest of the entry.</param>
    public record HistorySegment(SpoilerTier Tier, string Text);
}
