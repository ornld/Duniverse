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
    }
}