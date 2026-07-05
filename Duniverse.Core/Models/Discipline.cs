namespace Duniverse.Models
{
    /// <summary>
    /// Represents specialized training, terminologies, and "soft" mechanics.
    /// </summary>
    public class Discipline : DuneEntity
    {
        /// <summary>
        /// The prerequisites or inherent traits required to learn the discipline.
        /// </summary>
        public string? Requirements { get; set; }

        /// <summary>
        /// The practical application or physical manifestation of the discipline.
        /// </summary>
        public string? Mechanics { get; set; }
    }
}