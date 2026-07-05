using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// Represents a central figure or character in the universe.
    /// </summary>
    public class Persona : DuneEntity
    {
        /// <summary>
        /// The faction or house the character belongs to.
        /// </summary>
        public string? Affiliation { get; set; }

        /// <summary>
        /// The character's primary role or title (e.g., Mentat, Reverend Mother).
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// A collection of memorable quotes attributed to the character.
        /// </summary>
        public List<string> NotableQuotes { get; set; } = new List<string>();
    }
}