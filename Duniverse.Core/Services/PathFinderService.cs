using System;
using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Services
{
    /// <summary>
    /// Finds the shortest chain of relationships joining two entities - the "how is Duncan
    /// Idaho connected to Shai-Hulud?" question. It walks the same web of links the
    /// relationship graph draws (RelatedEntityIds in both directions, via
    /// EntityRegistry.GetDirectlyRelated), breadth-first, so the first time the destination
    /// turns up the route to it is guaranteed to use the fewest possible hops.
    /// </summary>
    public class PathFinderService
    {
        /// <summary>
        /// Returns the entities along the shortest route from <paramref name="fromId"/> to
        /// <paramref name="toId"/>, both endpoints included, or null when no route exists.
        /// The optional <paramref name="include"/> predicate excludes entities from the walk
        /// entirely (the spoiler gate passes one), so a hidden entity can neither anchor a
        /// route nor smuggle one through as an intermediate step. The optional
        /// <paramref name="linkVisible"/> predicate does the same job one level down, for a
        /// connection that is itself a later-book fact even though both entities it joins are
        /// visible; without it a route could hop along an edge the reader should not know about.
        /// </summary>
        public IReadOnlyList<DuneEntity>? FindShortestPath(EntityRegistry registry, string fromId, string toId,
            Func<DuneEntity, bool>? include = null, Func<SpoilerTier, bool>? linkVisible = null)
        {
            var from = registry.GetEntity(fromId);
            var to = registry.GetEntity(toId);

            if (from is null || to is null)
            {
                return null;
            }

            if (include is not null && (!include(from) || !include(to)))
            {
                return null;
            }

            if (string.Equals(from.Id, to.Id, StringComparison.OrdinalIgnoreCase))
            {
                return new List<DuneEntity> { from };
            }

            // Each discovered entity remembers which neighbor first reached it, so once the
            // destination appears the whole route can be read back by walking parents.
            var parentOf = new Dictionary<string, DuneEntity>(StringComparer.OrdinalIgnoreCase);
            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { from.Id };
            var queue = new Queue<DuneEntity>();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var neighbor in registry.GetDirectlyRelated(current.Id, linkVisible))
                {
                    if (!visited.Add(neighbor.Id))
                    {
                        continue;
                    }

                    if (include is not null && !include(neighbor))
                    {
                        continue;
                    }

                    parentOf[neighbor.Id] = current;

                    if (string.Equals(neighbor.Id, to.Id, StringComparison.OrdinalIgnoreCase))
                    {
                        return ReadBack(neighbor, parentOf);
                    }

                    queue.Enqueue(neighbor);
                }
            }

            return null;
        }

        /// <summary>
        /// Rebuilds the route by following each entity's recorded parent from the destination
        /// back to the start, then reverses it so callers read it start-to-destination.
        /// </summary>
        private static List<DuneEntity> ReadBack(DuneEntity destination, Dictionary<string, DuneEntity> parentOf)
        {
            var path = new List<DuneEntity> { destination };

            while (parentOf.TryGetValue(path[^1].Id, out var parent))
            {
                path.Add(parent);
            }

            path.Reverse();
            return path;
        }
    }
}
