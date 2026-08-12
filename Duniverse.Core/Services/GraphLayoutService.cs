using System;
using System.Collections.Generic;
using System.Linq;
using Duniverse.Models;

namespace Duniverse.Services
{
    /// <summary>
    /// Builds a local "ego graph" around one entity, itself plus neighbors out to a few hops,
    /// then arranges it with a force-directed simulation: nodes repel, edges pull like springs.
    /// No charting library, just coordinate math handed to the SVG.
    /// </summary>
    public class GraphLayoutService
    {
        private const int MaxNodes = 36;

        /// <summary>
        /// Walks outward from the center breadth-first, collecting every entity within maxDepth
        /// hops. Direct neighbors always make it in. If the deeper hops would push past MaxNodes
        /// I trim them, since a dense tangle reads as nothing at all.
        /// </summary>
        public EntityGraph BuildEgoGraph(EntityRegistry registry, string centerId, int maxDepth = 2,
            Func<DuneEntity, bool>? include = null, Func<SpoilerTier, bool>? linkVisible = null)
        {
            var graph = new EntityGraph();

            var center = registry.GetEntity(centerId);
            if (center is null)
            {
                return graph;
            }

            var visited = new Dictionary<string, DuneEntity>(StringComparer.OrdinalIgnoreCase) { [center.Id] = center };
            var edgeKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var edges = new List<GraphEdge>();

            var frontier = new List<DuneEntity> { center };

            for (int depth = 0; depth < maxDepth && frontier.Count > 0; depth++)
            {
                var nextFrontier = new List<DuneEntity>();

                foreach (var entity in frontier)
                {
                    foreach (var neighbor in registry.GetDirectlyRelated(entity.Id, linkVisible))
                    {
                        // Skip neighbors the caller wants hidden (the spoiler gate passes a
                        // predicate here), so they never become a node or leak through an edge.
                        if (include is not null && !include(neighbor))
                        {
                            continue;
                        }

                        var edgeKey = string.CompareOrdinal(entity.Id, neighbor.Id) < 0
                            ? $"{entity.Id}|{neighbor.Id}"
                            : $"{neighbor.Id}|{entity.Id}";

                        if (edgeKeys.Add(edgeKey))
                        {
                            edges.Add(new GraphEdge(entity.Id, neighbor.Id));
                        }

                        if (!visited.ContainsKey(neighbor.Id) && visited.Count < MaxNodes)
                        {
                            visited[neighbor.Id] = neighbor;
                            nextFrontier.Add(neighbor);
                        }
                    }
                }

                frontier = nextFrontier;
            }

            graph.Nodes.AddRange(visited.Values.Select(entity => new GraphNode
            {
                Id = entity.Id,
                Name = entity.Name,
                ShortDescription = entity.ShortDescription ?? "",
                Category = CategorySlug(entity),
                IsCenter = string.Equals(entity.Id, center.Id, StringComparison.OrdinalIgnoreCase),
            }));

            // Only keep edges between two nodes that actually made it into the final node set
            // (a deeper hop may have been trimmed by the MaxNodes cap above).
            var keptIds = new HashSet<string>(graph.Nodes.Select(n => n.Id), StringComparer.OrdinalIgnoreCase);
            graph.Edges.AddRange(edges.Where(e => keptIds.Contains(e.SourceId) && keptIds.Contains(e.TargetId)));

            return graph;
        }

        /// <summary>
        /// The whole visible archive as one graph. Hidden entities never enter the simulation, so
        /// the shape of the web leaks nothing about what's missing. I walk entities in a fixed
        /// order so the layout lands the same every visit.
        /// </summary>
        /// <param name="linkVisible">Covers the other case: two entities the reader can see,
        /// joined by a connection that's itself a later reveal.</param>
        public EntityGraph BuildFullGraph(EntityRegistry registry, Func<DuneEntity, bool>? include = null,
            Func<SpoilerTier, bool>? linkVisible = null)
        {
            var graph = new EntityGraph();

            var entities = registry.GetAllEntities<DuneEntity>()
                .Where(entity => include is null || include(entity))
                .OrderBy(entity => entity.Id, StringComparer.OrdinalIgnoreCase)
                .ToList();

            var admitted = new HashSet<string>(entities.Select(e => e.Id), StringComparer.OrdinalIgnoreCase);

            graph.Nodes.AddRange(entities.Select(entity => new GraphNode
            {
                Id = entity.Id,
                Name = entity.Name,
                ShortDescription = entity.ShortDescription ?? "",
                Category = CategorySlug(entity),
            }));

            var edgeKeys = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var entity in entities)
            {
                foreach (var neighbor in registry.GetDirectlyRelated(entity.Id, linkVisible))
                {
                    if (!admitted.Contains(neighbor.Id))
                    {
                        continue;
                    }

                    var edgeKey = string.CompareOrdinal(entity.Id, neighbor.Id) < 0
                        ? $"{entity.Id}|{neighbor.Id}"
                        : $"{neighbor.Id}|{entity.Id}";

                    if (edgeKeys.Add(edgeKey))
                    {
                        graph.Edges.Add(new GraphEdge(entity.Id, neighbor.Id));
                    }
                }
            }

            return graph;
        }

        /// <summary>
        /// Runs the spring-embedder in place, settling each node's X/Y inside the viewport. Nodes
        /// start on a seeded circle rather than at random, so the simulation converges the same
        /// way each time instead of jittering between runs.
        /// </summary>
        /// <param name="gravity">Optional pull toward the canvas center, as a fraction of a
        /// node's distance from it. Zero suits small ego graphs, whose pinned center already
        /// anchors them. Big free-floating graphs need some gravity or loose clusters drift
        /// apart.</param>
        /// <param name="repulsionRange">How far a node's repulsion reaches. Infinite (the default)
        /// is classic Fruchterman-Reingold, fine on small graphs. On big ones it pins the outer
        /// ring flat against the borders, so two or three ideal-distances keeps spacing
        /// local.</param>
        public void ApplyForceDirectedLayout(EntityGraph graph, double width, double height, int iterations = 300,
            double gravity = 0, double repulsionRange = double.PositiveInfinity)
        {
            var nodes = graph.Nodes;
            int count = nodes.Count;
            if (count == 0)
            {
                return;
            }

            double centerX = width / 2;
            double centerY = height / 2;
            double seedRadius = Math.Min(width, height) * 0.35;

            for (int i = 0; i < count; i++)
            {
                double angle = 2 * Math.PI * i / count;
                nodes[i].X = centerX + seedRadius * Math.Cos(angle);
                nodes[i].Y = centerY + seedRadius * Math.Sin(angle);
            }

            double area = width * height;
            double idealDistance = Math.Sqrt(area / count) * 0.9;
            double temperature = Math.Min(width, height) / 8;
            double cooling = temperature / iterations;

            var nodesById = nodes.ToDictionary(n => n.Id, StringComparer.OrdinalIgnoreCase);
            var adjacency = graph.Edges
                .SelectMany(e => new[] { (e.SourceId, e.TargetId), (e.TargetId, e.SourceId) })
                .ToLookup(pair => pair.Item1, pair => pair.Item2, StringComparer.OrdinalIgnoreCase);

            for (int step = 0; step < iterations; step++)
            {
                foreach (var node in nodes)
                {
                    node.ForceX = 0;
                    node.ForceY = 0;
                }

                // Repulsion: every pair of nodes pushes apart, like same-charge particles.
                for (int i = 0; i < count; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        var a = nodes[i];
                        var b = nodes[j];
                        double dx = a.X - b.X;
                        double dy = a.Y - b.Y;
                        double distance = Math.Max(Math.Sqrt(dx * dx + dy * dy), 0.01);
                        if (distance > repulsionRange)
                        {
                            continue;
                        }
                        double repulsion = (idealDistance * idealDistance) / distance;

                        double fx = (dx / distance) * repulsion;
                        double fy = (dy / distance) * repulsion;

                        a.ForceX += fx;
                        a.ForceY += fy;
                        b.ForceX -= fx;
                        b.ForceY -= fy;
                    }
                }

                // Attraction: connected nodes pull together, like a spring along each edge.
                foreach (var node in nodes)
                {
                    foreach (var neighborId in adjacency[node.Id])
                    {
                        if (!nodesById.TryGetValue(neighborId, out var neighbor))
                        {
                            continue;
                        }

                        double dx = node.X - neighbor.X;
                        double dy = node.Y - neighbor.Y;
                        double distance = Math.Max(Math.Sqrt(dx * dx + dy * dy), 0.01);
                        double attraction = (distance * distance) / idealDistance;

                        node.ForceX -= (dx / distance) * attraction * 0.5;
                        node.ForceY -= (dy / distance) * attraction * 0.5;
                    }
                }

                // Gravity: a gentle spring from every node toward the canvas center.
                if (gravity > 0)
                {
                    foreach (var node in nodes)
                    {
                        node.ForceX += (centerX - node.X) * gravity;
                        node.ForceY += (centerY - node.Y) * gravity;
                    }
                }

                // A locked center node acts as the anchor the rest of the graph organizes around.
                foreach (var node in nodes)
                {
                    if (node.IsCenter)
                    {
                        node.X = centerX;
                        node.Y = centerY;
                        continue;
                    }

                    double displacement = Math.Max(Math.Sqrt(node.ForceX * node.ForceX + node.ForceY * node.ForceY), 0.01);
                    double cappedDisplacement = Math.Min(displacement, temperature);

                    node.X += (node.ForceX / displacement) * cappedDisplacement;
                    node.Y += (node.ForceY / displacement) * cappedDisplacement;

                    // Keep every node comfortably inside the viewport with some breathing room.
                    double margin = 40;
                    node.X = Math.Clamp(node.X, margin, width - margin);
                    node.Y = Math.Clamp(node.Y, margin, height - margin);
                }

                temperature -= cooling;
            }
        }

        /// <summary>
        /// Maps an entity to the same slug my /category/{slug} routes use, so graph nodes
        /// color-code with the rest of the site and link straight back into the browse page.
        /// </summary>
        public static string CategorySlug(DuneEntity entity) => entity switch
        {
            Artifact => "artifacts",
            Discipline => "disciplines",
            FloraFauna => "flora-fauna",
            HistoricalEvent => "historical-events",
            House => "houses",
            Organization => "organizations",
            Persona => "personas",
            TheologicalSystem => "theological-systems",
            Vehicle => "vehicles",
            World => "worlds",
            _ => "unknown",
        };

        /// <summary>
        /// The reader-facing name of an entity's category, matching the heading its browse
        /// page carries. Pairs with <see cref="CategorySlug"/> so a link can name the same
        /// category page it points at.
        /// </summary>
        public static string CategoryTitle(DuneEntity entity) => entity switch
        {
            Artifact => "Artifacts",
            Discipline => "Disciplines",
            FloraFauna => "Flora & Fauna",
            HistoricalEvent => "Historical Events",
            House => "Houses",
            Organization => "Organizations",
            Persona => "Personas",
            TheologicalSystem => "Theological Systems",
            Vehicle => "Vehicles",
            World => "Worlds & Locations",
            _ => "the archive",
        };
    }
}
