using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Duniverse.Models;

namespace Duniverse.Services
{
    public class EntityRegistry
    {
        // The master databank holding every entity.
        // StringComparer.OrdinalIgnoreCase makes it forgiving if someone types a lowercase letter!
        private readonly Dictionary<string, DuneEntity> _database = new Dictionary<string, DuneEntity>(StringComparer.OrdinalIgnoreCase);

        // Reverse-link index: for each ID, the IDs of every entity whose RelatedEntityIds points
        // at it. I build it at registration time so lookups only touch real neighbors instead of
        // scanning the whole databank on every page view.
        private readonly Dictionary<string, HashSet<string>> _inboundLinks = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        // Labeled relationships, keyed "viewedId|otherId" -> what the other entity is to the
        // viewed one. Each registered relationship writes two entries, one per direction.
        private readonly Dictionary<string, RelationshipLabel> _relationshipLabels = new Dictionary<string, RelationshipLabel>(StringComparer.OrdinalIgnoreCase);

        // Links I invented, keyed the same way, holding the tier that justified them. Hiding the
        // label "Wife" still leaves a bare line, which is the fact itself. Seeder-declared links
        // never land here, since those stand on their own.
        private readonly Dictionary<string, SpoilerTier> _inventedLinks = new Dictionary<string, SpoilerTier>(StringComparer.OrdinalIgnoreCase);

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
        /// Every Persona in this house or order, with spoiler filtering left to the caller. Two
        /// masters means two IDs and both rosters. I take the ID, not the display name, since
        /// substring matching on prose got it wrong both ways.
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
        /// One entity at random, or null on an empty databank. This backs "Surprise me". The
        /// optional filter narrows the pool, and the spoiler gate passes one so nobody lands on
        /// a book they haven't reached.
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
        /// Every entity whose Name or <see cref="DuneEntity.Aliases"/> contains the query. I
        /// normalize both first, so "muaddib" still matches "Muad'Dib". Aliases count as fully as
        /// the display name, since readers know figures by whatever name stuck.
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
        /// Every entity whose entry text mentions the query, searching the body instead of the
        /// name, since readers remember facts first. I keep it out of <see cref="Resolve"/>: a
        /// body hit is weaker than a name and shouldn't redirect.
        /// </summary>
        /// <param name="layerVisible">Keeps the search inside what the reader has earned. Without
        /// it, a phrase from a held-back layer would surface an excerpt quoting the very sentence
        /// the layer exists to withhold.</param>
        public IEnumerable<DuneEntity> SearchByContent(string query,
            Func<SpoilerTier, bool>? layerVisible = null)
        {
            var normalizedQuery = Normalize(query);
            if (normalizedQuery.Length < 3)
            {
                return Array.Empty<DuneEntity>();
            }

            // Every word has to appear, but not side by side. Nobody recalls the archive's exact
            // phrasing ("sandworm tooth" for "tooth of a slain sandworm"), and requiring all the
            // words still keeps one loose word from matching.
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
                var text = Normalize(ReadableText(entity, layerVisible));
                return terms.All(term => text.Contains(term, StringComparison.Ordinal));
            });
        }

        /// <summary>
        /// Everything on a record this reader is allowed to read: summary, opening history, and
        /// only the layers their progress unlocked. Anything reading an entry's prose on a
        /// reader's behalf goes through here, so a held-back layer can't surface elsewhere.
        /// </summary>
        public static string ReadableText(DuneEntity entity, Func<SpoilerTier, bool>? layerVisible = null)
        {
            var builder = new StringBuilder();
            builder.Append(entity.ShortDescription ?? string.Empty);
            builder.Append(' ').Append(entity.DetailedHistory ?? string.Empty);

            foreach (var layer in VisibleLayers(entity, layerVisible))
            {
                builder.Append(' ').Append(layer.Text);
            }

            return builder.ToString();
        }

        /// <summary>
        /// The later chapters a reader has earned, in written order. Passing no predicate hands
        /// back the whole story (the console app, anything with no spoiler notion), so this is a
        /// filter you opt into.
        /// </summary>
        public static IEnumerable<HistorySegment> VisibleLayers(DuneEntity entity,
            Func<SpoilerTier, bool>? layerVisible = null)
        {
            return layerVisible is null
                ? entity.HistoryLayers
                : entity.HistoryLayers.Where(layer => layerVisible(layer.Tier));
        }

        /// <summary>
        /// The entities whose name sits closest by edit distance, for suggesting a fix when an
        /// exact ID and a name search both miss ("Pull Atriedes"). The allowed distance scales
        /// with query length. Returns everything tied at the closest distance.
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
        /// Turns a free-form query (an ID, a full or partial name, a typo) into either one entity
        /// or a list to pick from. Exact ID first, then a name search, then closest-distance
        /// suggestions. Every UI gets the same behavior.
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
        /// Every entity of one category connected to this ID, in either direction: entities
        /// listing this ID in their own RelatedEntityIds, plus the ones this ID points at. A link
        /// recorded on one side finds both.
        /// </summary>
        public IEnumerable<T> GetRelatedEntities<T>(string relatedId,
            Func<SpoilerTier, bool>? linkVisible = null) where T : DuneEntity
        {
            return GetDirectlyRelated(relatedId, linkVisible).OfType<T>();
        }

        /// <summary>
        /// Every entity directly connected to this ID, whatever its type. The untyped counterpart
        /// to GetRelatedEntities&lt;T&gt;, used by the graph to walk the web one hop at a time
        /// without knowing what it'll find.
        /// </summary>
        public IEnumerable<DuneEntity> GetDirectlyRelated(string id,
            Func<SpoilerTier, bool>? linkVisible = null)
        {
            if (!_database.TryGetValue(id, out var source))
            {
                yield break;
            }

            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { id };

            // The seen check runs before the tier check on purpose. A neighbor held back for
            // spoilers is still marked seen, so the inbound pass below can't hand it back.
            foreach (var relatedId in source.RelatedEntityIds)
            {
                if (_database.TryGetValue(relatedId, out var target) && seen.Add(target.Id)
                    && !IsHeldBack(source.Id, target.Id, linkVisible))
                {
                    yield return target;
                }
            }

            if (_inboundLinks.TryGetValue(source.Id, out var referrers))
            {
                foreach (var referrerId in referrers)
                {
                    if (_database.TryGetValue(referrerId, out var referrer) && seen.Add(referrer.Id)
                        && !IsHeldBack(source.Id, referrer.Id, linkVisible))
                    {
                        yield return referrer;
                    }
                }
            }
        }

        /// <summary>
        /// Whether a connection should stay out of sight: true only for a link I invented whose
        /// book the caller says the reader hasn't reached. Pass no predicate and you see
        /// everything, so this is opt-in rather than opt-out.
        /// </summary>
        private bool IsHeldBack(string viewedId, string otherId, Func<SpoilerTier, bool>? linkVisible)
        {
            return linkVisible is not null
                && _inventedLinks.TryGetValue($"{viewedId}|{otherId}", out var tier)
                && !linkVisible(tier);
        }

        /// <summary>
        /// Loads labeled relationships, one entry per direction. A labeled pair that isn't linked
        /// in either entity's RelatedEntityIds becomes a real connection here, so I can add canon
        /// links without touching the seeders. Run this after every seeder registers.
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

                    // Remember that this one is ours, in both directions, so a reader who has
                    // not reached the book it comes from never gets handed the bare edge.
                    _inventedLinks[$"{from.Id}|{to.Id}"] = rel.Tier;
                    _inventedLinks[$"{to.Id}|{from.Id}"] = rel.Tier;

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
        /// Every House in a historical rivalry with this one, either direction: Houses listing
        /// this ID in their HistoricalRivalries, plus the ones this House points at. Recording a
        /// rivalry on one side shows it for both.
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