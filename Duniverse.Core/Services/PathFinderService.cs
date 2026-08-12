using System;
using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Services
{
    /// <summary>
    /// Finds the shortest chain of relationships joining two entities, the "how is Duncan Idaho
    /// connected to Shai-Hulud?" question. It walks the same web the graph draws, breadth-first,
    /// so the first route to turn up uses the fewest hops.
    /// </summary>
    public class PathFinderService
    {
        /// <summary>
        /// The entities along the shortest route from one id to the other, both endpoints
        /// included, or null when there's no route.
        /// </summary>
        /// <param name="include">Drops entities from the walk entirely. The spoiler gate passes
        /// one, so a hidden record can't anchor a route or smuggle one through as a middle
        /// step.</param>
        /// <param name="linkVisible">Same job one level down, for a connection that's itself a
        /// later reveal even when both entities show. Without it a route could hop along an edge
        /// the reader shouldn't know about.</param>
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
