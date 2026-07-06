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
        /// Relative position on the saga's chronological timeline. Timeframe is free text
        /// ("Roughly 10,000 years before Paul's birth") and isn't sortable on its own, so this
        /// gives the Timeline page a real order to render against. Values are spaced by 10 so
        /// future events can be inserted between existing ones without renumbering everything.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// The primary outcomes or lingering impacts of the event on the universe.
        /// </summary>
        public string? LastingImpact { get; set; }

        /// <summary>
        /// The event's date in Guild reckoning ("10191 AG", "201 to 108 BG"), the Imperial
        /// calendar counted from the Spacing Guild's monopoly. A display string rather than a
        /// number: some events span ranges, and pre-Guild dates run backward. Null means the
        /// chronology gives no usable date, and the timeline simply shows no year for it.
        /// </summary>
        public string? DateAG { get; set; }

        /// <summary>
        /// The historical era the event belongs to ("The Rise of Muad'Dib"). The timeline page
        /// groups its entries under these as section headings, in SortOrder sequence.
        /// </summary>
        public string? Era { get; set; }
    }
}