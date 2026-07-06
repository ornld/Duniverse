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
        /// The earliest work by which this entity is safe to encounter. Defaults to Dune, which
        /// means no spoiler protection ever hides it. Entities first revealed in later novels or
        /// in the Expanded Universe are raised above this default (see SpoilerTierMap in
        /// Duniverse.Core/Data), so the site's optional spoiler gate can hold them back from a
        /// reader who has not read that far yet.
        /// </summary>
        public SpoilerTier SpoilerTier { get; set; } = SpoilerTier.Dune;

        /// <summary>
        /// Returns a string that represents the current entity.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} (ID: {Id})";
        }
    }
}