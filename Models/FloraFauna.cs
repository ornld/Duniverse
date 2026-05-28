namespace Duniverse.Models
{
    /// <summary>
    /// Represents the biological organisms found throughout the universe.
    /// </summary>
    public class FloraFauna : DuneEntity
    {
        /// <summary>
        /// Indicates whether the entity is plant life or animal life.
        /// </summary>
        public string? BiologicalClassification { get; set; }

        /// <summary>
        /// Any specialized products derived from the organism (e.g., Melange, Water of Life).
        /// </summary>
        public string? DerivedProducts { get; set; }
    }
}