using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// The base blueprint for all entities in the encyclopedia.
    /// </summary>
    public abstract class DuneEntity
    {
        /// <summary>
        /// A unique identifier for the entity, used as the Dictionary key.
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// The display name of the entity.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// A brief summary displayed on the front of the encyclopedia card.
        /// </summary>
        public string? ShortDescription { get; set; }

        /// <summary>
        /// The detailed text revealed when the card is flipped over.
        /// </summary>
        public string? DetailedHistory { get; set; }

        /// <summary>
        /// The local file path or URL to the image used on the card.
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// A list of IDs representing other related entities for hyperlink navigation.
        /// </summary>
        public List<string> RelatedEntityIds { get; set; } = new List<string>();

        /// <summary>
        /// Returns a string that represents the current entity.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} (ID: {Id})";
        }
    }
}