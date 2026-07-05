using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// Represents a Great or Minor House within the political framework of the Imperium.
    /// </summary>
    public class House : DuneEntity
    {
        /// <summary>
        /// A description or image path of the House's official emblem.
        /// </summary>
        public string? Sigil { get; set; }

        /// <summary>
        /// The official slogan or war cry of the House.
        /// </summary>
        public string? Motto { get; set; }

        /// <summary>
        /// A list of opposing Houses or factions this House has historically warred against.
        /// </summary>
        public List<string> HistoricalRivalries { get; set; } = new List<string>();
    }
}