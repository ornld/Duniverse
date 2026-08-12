using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// Represents a central figure or character in the universe.
    /// </summary>
    public class Persona : DuneEntity
    {
        /// <summary>
        /// The faction or house, written for a reader. This is the line the record shows, so I
        /// let it keep the nuance a roster can't hold ("Fremen (secretly House Corrino)",
        /// "Honored Matres (later Bene Gesserit)").
        /// </summary>
        public string? Affiliation { get; set; }

        /// <summary>
        /// The houses and orders this character actually belongs to, what Known Members rosters
        /// run on. I can't match the prose above ("Fremen" sits inside "Museum Fremen"). The
        /// test is who counts them as their own, not blood or name.
        /// </summary>
        public List<string> AffiliationIds { get; set; } = new List<string>();

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