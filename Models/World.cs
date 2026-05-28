using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// Represents a planet or moon in the Imperium.
    /// </summary>
    public class World : DuneEntity
    {
        /// <summary>
        /// Details regarding climate, terrain, and ecology.
        /// </summary>
        public string? EnvironmentalData { get; set; }

        /// <summary>
        /// The political entity currently in control of the world.
        /// </summary>
        public string? RulingHouse { get; set; }

        /// <summary>
        /// A collection of specific cultural practices native to the world.
        /// </summary>
        public List<string> LocalCustoms { get; set; } = new List<string>();
    }
}