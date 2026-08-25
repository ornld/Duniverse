namespace Duniverse.Models
{
    /// <summary>
    /// Represents chronological events or eras of significant impact.
    /// </summary>
    public class HistoricalEvent : DuneEntity
    {
        /// <summary>
        /// The accepted dates or chronological period during which the event occurred.
        /// </summary>
        public string? Timeframe { get; set; }

        /// <summary>
        /// Where this sits on the timeline. Timeframe is free text and won't sort, so the
        /// Timeline page needs a real number to render against. I space these by 10 so a new
        /// event can slot between two without renumbering.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// The primary outcomes or lingering impacts of the event on the universe.
        /// </summary>
        public string? LastingImpact { get; set; }

        /// <summary>
        /// The date in Guild reckoning ("10191 AG", "201 to 108 BG"). I keep it as a string, not
        /// a number, since some events span ranges and pre-Guild dates run backward. Null just
        /// means the timeline shows no year.
        /// </summary>
        public string? DateAG { get; set; }

        /// <summary>
        /// The historical era the event belongs to ("The Rise of Muad'Dib"). The timeline page
        /// groups its entries under these as section headings, in SortOrder sequence.
        /// </summary>
        public string? Era { get; set; }

        /// <summary>
        /// The date as a number the timeline can measure with, so a year's gap sits closer than
        /// a century's. Negative counts BG. A range or a circa takes its opening year, and
        /// <see cref="DateAG"/> still carries what the reader sees.
        /// </summary>
        /// <remarks>
        /// Null leaves an event evenly spaced instead of placed, which is the honest answer for
        /// a date the chronicles never fixed.
        /// </remarks>
        public int? YearAG { get; set; }
    }
}