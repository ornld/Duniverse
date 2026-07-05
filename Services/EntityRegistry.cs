using System;
using System.Collections.Generic;
using System.Linq;
using Duniverse.Models;

namespace Duniverse.Services
{
    public class EntityRegistry
    {
        // The master databank holding every entity. 
        // StringComparer.OrdinalIgnoreCase makes it forgiving if someone types a lowercase letter!
        private readonly Dictionary<string, DuneEntity> _database = new Dictionary<string, DuneEntity>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Loads a list of entities into the master dictionary.
        /// </summary>
        public void RegisterEntities<T>(IEnumerable<T> entities) where T : DuneEntity
        {
            foreach (var entity in entities)
            {
                _database[entity.Id] = entity;
            }
        }

        /// <summary>
        /// Retrieves a single primary entity by its exact ID.
        /// </summary>
        public DuneEntity? GetEntity(string id)
        {
            _database.TryGetValue(id, out var entity);
            return entity;
        }

        /// <summary>
        /// Finds every entity whose Name contains the given query, case-insensitive. Lets a
        /// caller search by a familiar name (e.g. "Paul Atreides") without knowing the exact ID.
        /// </summary>
        public IEnumerable<DuneEntity> SearchByName(string query)
        {
            return _database.Values
                .Where(entity => entity.Name.Contains(query, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves all entities of a specific category (e.g., Artifact) that are connected
        /// to the given ID, in either direction: entities that list this ID in their own
        /// RelatedEntityIds (reverse), plus entities that this ID's own RelatedEntityIds points
        /// at (forward). A link recorded on just one side of a relationship is enough for both
        /// sides to find each other.
        /// </summary>
        public IEnumerable<T> GetRelatedEntities<T>(string relatedId) where T : DuneEntity
        {
            var reverseMatches = _database.Values
                .OfType<T>()
                .Where(entity => entity.RelatedEntityIds.Contains(relatedId, StringComparer.OrdinalIgnoreCase));

            var forwardMatches = Enumerable.Empty<T>();
            if (_database.TryGetValue(relatedId, out var sourceEntity))
            {
                forwardMatches = sourceEntity.RelatedEntityIds
                    .Select(GetEntity)
                    .OfType<T>();
            }

            return reverseMatches
                .Concat(forwardMatches)
                .DistinctBy(entity => entity.Id, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Retrieves every House locked in a historical rivalry with the given House ID, in
        /// either direction: Houses that list this ID in their own HistoricalRivalries, plus
        /// Houses that this ID's own HistoricalRivalries points at. A rivalry only needs to be
        /// recorded on one side to show up for both Houses.
        /// </summary>
        public IEnumerable<House> GetRivalHouses(string houseId)
        {
            var reverseMatches = _database.Values
                .OfType<House>()
                .Where(house => house.HistoricalRivalries.Contains(houseId, StringComparer.OrdinalIgnoreCase));

            var forwardMatches = Enumerable.Empty<House>();
            if (_database.TryGetValue(houseId, out var sourceEntity) && sourceEntity is House sourceHouse)
            {
                forwardMatches = sourceHouse.HistoricalRivalries
                    .Select(GetEntity)
                    .OfType<House>();
            }

            return reverseMatches
                .Concat(forwardMatches)
                .DistinctBy(house => house.Id, StringComparer.OrdinalIgnoreCase);
        }
    }
}