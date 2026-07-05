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
        /// Retrieves every registered entity of a given category (e.g., every Persona),
        /// regardless of how they relate to anything else. Used for category browse pages,
        /// as opposed to GetRelatedEntities which only returns entities connected to one ID.
        /// </summary>
        public IEnumerable<T> GetAllEntities<T>() where T : DuneEntity
        {
            return _database.Values.OfType<T>();
        }

        /// <summary>
        /// Finds every entity whose Name contains the given query. Names and queries are
        /// normalized (punctuation stripped, case folded) first, so "muaddib" still matches
        /// "Muad'Dib" despite the apostrophe.
        /// </summary>
        public IEnumerable<DuneEntity> SearchByName(string query)
        {
            var normalizedQuery = Normalize(query);
            return _database.Values
                .Where(entity => Normalize(entity.Name).Contains(normalizedQuery, StringComparison.Ordinal));
        }

        /// <summary>
        /// Finds the entities whose Name is the closest edit-distance match to the given query,
        /// for suggesting corrections when an exact ID and a substring name search both come up
        /// empty (e.g. a typo like "Pull Atriedes"). The allowed distance scales with the
        /// query's length so short queries don't end up matching everything. Returns every
        /// entity tied for the closest distance found, or an empty list if nothing is close
        /// enough to be a reasonable suggestion.
        /// </summary>
        public IReadOnlyList<DuneEntity> FindClosestByName(string query)
        {
            var normalizedQuery = Normalize(query);
            if (normalizedQuery.Length == 0)
            {
                return Array.Empty<DuneEntity>();
            }

            int maxDistance = Math.Max(2, normalizedQuery.Length / 3);

            var withinRange = _database.Values
                .Select(entity => (Entity: entity, Distance: LevenshteinDistance(normalizedQuery, Normalize(entity.Name))))
                .Where(scored => scored.Distance <= maxDistance)
                .OrderBy(scored => scored.Distance)
                .ToList();

            if (withinRange.Count == 0)
            {
                return Array.Empty<DuneEntity>();
            }

            int closestDistance = withinRange[0].Distance;
            return withinRange
                .Where(scored => scored.Distance == closestDistance)
                .Select(scored => scored.Entity)
                .ToList();
        }

        /// <summary>
        /// Lowercases and strips punctuation so that names differing only by an apostrophe,
        /// hyphen, or letter case are treated as equivalent for search purposes.
        /// </summary>
        private static string Normalize(string value)
        {
            var letters = value.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
            return new string(letters.ToArray()).ToLowerInvariant();
        }

        /// <summary>
        /// Computes the Levenshtein distance (minimum single-character insertions, deletions,
        /// or substitutions needed to turn one string into the other) between two strings.
        /// </summary>
        private static int LevenshteinDistance(string a, string b)
        {
            var distances = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++) distances[i, 0] = i;
            for (int j = 0; j <= b.Length; j++) distances[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int substitutionCost = a[i - 1] == b[j - 1] ? 0 : 1;
                    distances[i, j] = Math.Min(
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + substitutionCost);
                }
            }

            return distances[a.Length, b.Length];
        }

        /// <summary>
        /// Resolves a free-form query (an exact ID, a full or partial name, or a typo) down to
        /// either a single matching entity or a list of candidates to disambiguate between.
        /// Tries an exact ID match first, then a substring name search, then falls back to
        /// closest-edit-distance suggestions - the same tiered resolution used by the console
        /// app, factored out so any UI (web included) gets identical behavior for free.
        /// </summary>
        public ResolveResult Resolve(string query)
        {
            var exact = GetEntity(query);
            if (exact != null)
            {
                return new ResolveResult(exact, Array.Empty<DuneEntity>());
            }

            var nameMatches = SearchByName(query).ToList();
            if (nameMatches.Count == 1)
            {
                return new ResolveResult(nameMatches[0], Array.Empty<DuneEntity>());
            }
            if (nameMatches.Count > 1)
            {
                return new ResolveResult(null, nameMatches);
            }

            var suggestions = FindClosestByName(query);
            if (suggestions.Count == 1)
            {
                return new ResolveResult(suggestions[0], Array.Empty<DuneEntity>());
            }
            if (suggestions.Count > 1)
            {
                return new ResolveResult(null, suggestions);
            }

            return new ResolveResult(null, Array.Empty<DuneEntity>());
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

    /// <summary>
    /// The outcome of resolving a search query: either a single Entity, or a list of
    /// Candidates to disambiguate between. Exactly one of the two is populated.
    /// </summary>
    public readonly record struct ResolveResult(DuneEntity? Entity, IReadOnlyList<DuneEntity> Candidates);
}