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

        // Reverse-link index: for each ID, the IDs of every entity whose RelatedEntityIds points
        // at it. Maintained at registration time so relationship lookups only touch actual
        // neighbors instead of scanning the whole databank on every page view.
        private readonly Dictionary<string, HashSet<string>> _inboundLinks = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        // Labeled relationships, keyed "viewedId|otherId" -> what the other entity is to the
        // viewed one. Each registered relationship writes two entries, one per direction.
        private readonly Dictionary<string, RelationshipLabel> _relationshipLabels = new Dictionary<string, RelationshipLabel>(StringComparer.OrdinalIgnoreCase);

        /// <summary>The total number of registered entities.</summary>
        public int Count => _database.Count;

        /// <summary>
        /// Loads a list of entities into the master dictionary and indexes their outgoing links.
        /// </summary>
        public void RegisterEntities<T>(IEnumerable<T> entities) where T : DuneEntity
        {
            foreach (var entity in entities)
            {
                // If an ID is re-registered, drop the old entity's links before indexing the new ones.
                if (_database.TryGetValue(entity.Id, out var replaced))
                {
                    foreach (var targetId in replaced.RelatedEntityIds)
                    {
                        if (_inboundLinks.TryGetValue(targetId, out var referrers))
                        {
                            referrers.Remove(replaced.Id);
                        }
                    }
                }

                _database[entity.Id] = entity;

                foreach (var targetId in entity.RelatedEntityIds)
                {
                    if (!_inboundLinks.TryGetValue(targetId, out var referrers))
                    {
                        referrers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        _inboundLinks[targetId] = referrers;
                    }
                    referrers.Add(entity.Id);
                }
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
        /// Every Persona who belongs to the given house or organization, found by ID. A figure
        /// who serves two masters carries two IDs and shows up on both rosters, which is the
        /// truthful answer. Callers apply their own spoiler filter.
        ///
        /// This is the reverse of the link a Persona already shows: a member's record names
        /// their house, but the house's record had no way to name its members.
        ///
        /// Takes the ID and not the display name on purpose. Matching the name meant matching a
        /// substring of free-text prose, which got it wrong in both directions: a member whose
        /// affiliation read "House Corrino" never appeared on his own House Fenring roster, and
        /// any Museum Fremen would have landed on the Fremen roster because one name contains
        /// the other. An ID is exact and it is the same key the rest of the archive links by.
        /// </summary>
        public IEnumerable<Persona> GetAffiliates(string organizationId)
        {
            if (string.IsNullOrWhiteSpace(organizationId))
            {
                return Array.Empty<Persona>();
            }

            return _database.Values
                .OfType<Persona>()
                .Where(persona => persona.AffiliationIds
                    .Contains(organizationId, StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns a single entity chosen at random from the whole databank, or null if the
        /// databank is empty. Backs the "Surprise me" control, which drops a reader on an
        /// arbitrary entity page as a starting point for exploring the archive. An optional
        /// filter narrows the pool - the spoiler gate passes one so a reader with protection on
        /// never lands on an entity from a book they have not reached yet.
        /// </summary>
        public DuneEntity? GetRandomEntity(Func<DuneEntity, bool>? filter = null)
        {
            var pool = (filter is null ? _database.Values.AsEnumerable() : _database.Values.Where(filter)).ToList();
            if (pool.Count == 0)
            {
                return null;
            }

            return pool[Random.Shared.Next(pool.Count)];
        }

        /// <summary>
        /// Finds every entity whose Name or any of its <see cref="DuneEntity.Aliases"/> contains
        /// the given query. Names and queries are normalized (punctuation stripped, case folded)
        /// first, so "muaddib" still matches "Muad'Dib" despite the apostrophe. Aliases count as
        /// fully as the display name, since the name a reader happens to know a figure by is not
        /// always the one the record is filed under.
        /// </summary>
        public IEnumerable<DuneEntity> SearchByName(string query)
        {
            var normalizedQuery = Normalize(query);
            return _database.Values
                .Where(entity => NamesOf(entity)
                    .Any(name => Normalize(name).Contains(normalizedQuery, StringComparison.Ordinal)));
        }

        /// <summary>Every name an entity answers to: its display name first, then its aliases.</summary>
        private static IEnumerable<string> NamesOf(DuneEntity entity)
        {
            yield return entity.Name;
            foreach (var alias in entity.Aliases)
            {
                yield return alias;
            }
        }

        /// <summary>
        /// Finds every entity whose entry text mentions the given query, searching the summary
        /// and the history rather than the name. Readers remember facts before they remember
        /// names ("the tooth with the poison gas"), and a name-only search answers none of
        /// those. Text is normalized the same way names are, so an apostrophe or a capital
        /// never decides a match.
        ///
        /// Deliberately kept out of <see cref="Resolve"/>: that chain decides what a URL and a
        /// bare Enter press mean, and it navigates on a single hit. A phrase found in the body
        /// of an entry is a weaker signal than a name, so it belongs in a list the reader
        /// chooses from, never in a redirect. Short queries are refused because two letters
        /// appear in almost every entry and would return the whole archive.
        /// </summary>
        public IEnumerable<DuneEntity> SearchByContent(string query)
        {
            var normalizedQuery = Normalize(query);
            if (normalizedQuery.Length < 3)
            {
                return Array.Empty<DuneEntity>();
            }

            // Every word has to appear, but not side by side. A reader recalling a fact rarely
            // recalls the archive's exact phrasing ("sandworm tooth" for "tooth of a slain
            // sandworm"), so demanding the literal phrase would fail the very searches this is
            // here to answer. Requiring all the words keeps it from matching on one loose word.
            var terms = normalizedQuery
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Distinct()
                .ToArray();

            if (terms.Length == 0)
            {
                return Array.Empty<DuneEntity>();
            }

            return _database.Values.Where(entity =>
            {
                var text = Normalize((entity.ShortDescription ?? string.Empty) + " " + (entity.DetailedHistory ?? string.Empty));
                return terms.All(term => text.Contains(term, StringComparison.Ordinal));
            });
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

            // Scored against every name the entity answers to, so a typo on an alias
            // ("Muaddib", "Usal") is corrected as readily as a typo on the display name.
            var withinRange = _database.Values
                .Select(entity => (
                    Entity: entity,
                    Distance: NamesOf(entity).Min(name => LevenshteinDistance(normalizedQuery, Normalize(name)))))
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
            return GetDirectlyRelated(relatedId).OfType<T>();
        }

        /// <summary>
        /// Retrieves every entity directly connected to the given ID, in either direction and
        /// regardless of type - the untyped counterpart to GetRelatedEntities&lt;T&gt;, used by
        /// the relationship graph to walk the web of connections one hop at a time without
        /// needing to know in advance what categories it will find.
        /// </summary>
        public IEnumerable<DuneEntity> GetDirectlyRelated(string id)
        {
            if (!_database.TryGetValue(id, out var source))
            {
                yield break;
            }

            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { id };

            foreach (var relatedId in source.RelatedEntityIds)
            {
                if (_database.TryGetValue(relatedId, out var target) && seen.Add(target.Id))
                {
                    yield return target;
                }
            }

            if (_inboundLinks.TryGetValue(source.Id, out var referrers))
            {
                foreach (var referrerId in referrers)
                {
                    if (_database.TryGetValue(referrerId, out var referrer) && seen.Add(referrer.Id))
                    {
                        yield return referrer;
                    }
                }
            }
        }

        /// <summary>
        /// Loads labeled relationships into the lookup, one entry per direction. A labeled pair
        /// that isn't linked in either entity's RelatedEntityIds becomes a real connection here,
        /// so the relationship map can introduce canon links (Paul and his grandfather the
        /// Baron) without touching the seeders. The inbound-link index is kept in step, which is
        /// why this must run after every seeder has registered.
        /// </summary>
        public void RegisterRelationships(IEnumerable<EntityRelationship> relationships)
        {
            foreach (var rel in relationships)
            {
                // Viewing To, the other entity is From, described by FromRole; and vice versa.
                _relationshipLabels[$"{rel.ToId}|{rel.FromId}"] = new RelationshipLabel(rel.FromRole, rel.Tier);
                _relationshipLabels[$"{rel.FromId}|{rel.ToId}"] = new RelationshipLabel(rel.ToRole, rel.Tier);

                if (!_database.TryGetValue(rel.FromId, out var from) || !_database.TryGetValue(rel.ToId, out var to))
                {
                    continue;
                }

                bool alreadyLinked =
                    from.RelatedEntityIds.Contains(to.Id, StringComparer.OrdinalIgnoreCase) ||
                    to.RelatedEntityIds.Contains(from.Id, StringComparer.OrdinalIgnoreCase);

                if (!alreadyLinked)
                {
                    from.RelatedEntityIds.Add(to.Id);

                    if (!_inboundLinks.TryGetValue(to.Id, out var referrers))
                    {
                        referrers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        _inboundLinks[to.Id] = referrers;
                    }
                    referrers.Add(from.Id);
                }
            }
        }

        /// <summary>
        /// Looks up the label describing what <paramref name="otherId"/> is to
        /// <paramref name="viewedId"/> ("Mother", "Twin sister", "Slain in the duel"), or null
        /// when the pair has no recorded label. Callers decide whether the reader should see it
        /// by checking the label's spoiler tier.
        /// </summary>
        public RelationshipLabel? GetRelationshipLabel(string viewedId, string otherId)
        {
            return _relationshipLabels.TryGetValue($"{viewedId}|{otherId}", out var label) ? label : null;
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