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
        /// Other names this entity goes by, searchable and shown as "Also known as". A reader
        /// who only knows Muad'Dib still has to find him. I leave out any alias that's itself a
        /// reveal, since search skips the spoiler gate.
        /// </summary>
        public List<string> Aliases { get; set; } = new List<string>();

        /// <summary>
        /// A brief summary displayed on the front of the encyclopedia card.
        /// </summary>
        public string? ShortDescription { get; set; }

        /// <summary>
        /// The text behind the card flip. It's safe the moment the record itself is, so I keep
        /// nothing here past the book the record first appears in. Anything later goes in
        /// <see cref="HistoryLayers"/>.
        /// </summary>
        public string? DetailedHistory { get; set; }

        /// <summary>
        /// The rest of the story, each part waiting on the book that earns it. Empty for records
        /// whose whole life fits one novel. I keep declaration order, not tier order, since the
        /// Expanded Universe doesn't slot onto the end.
        /// </summary>
        public List<HistorySegment> HistoryLayers { get; set; } = new List<HistorySegment>();

        /// <summary>
        /// A list of IDs representing other related entities for hyperlink navigation.
        /// </summary>
        public List<string> RelatedEntityIds { get; set; } = new List<string>();

        /// <summary>
        /// The earliest book by which this entity is safe to meet. Defaults to Dune, so nothing
        /// hides it. I raise anything first revealed later in SpoilerTierMap, and the gate holds
        /// those back from a reader who hasn't gotten there.
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