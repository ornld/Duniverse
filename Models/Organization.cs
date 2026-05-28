namespace Duniverse.Models
{
    /// <summary>
    /// Represents formal factions, schools, or guilds.
    /// </summary>
    public class Organization : DuneEntity
    {
        /// <summary>
        /// The primary world or location where the organization operates.
        /// </summary>
        public string? Headquarters { get; set; }

        /// <summary>
        /// The overarching goal or service provided by the organization.
        /// </summary>
        public string? PrimaryDirective { get; set; }
    }
}