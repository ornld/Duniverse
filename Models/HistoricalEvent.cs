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
        /// The primary outcomes or lingering impacts of the event on the universe.
        /// </summary>
        public string? LastingImpact { get; set; }
    }
}