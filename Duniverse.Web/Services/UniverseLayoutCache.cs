using System;
using System.Collections.Generic;
using System.Text;
using Duniverse.Models;

namespace Duniverse.Web.Services
{
    /// <summary>
    /// I don't want the force sim rerunning on every visit, so I keep where /universe settled.
    /// Same records settle the same way, and the records are the key, so nobody sees anyone
    /// they haven't unlocked.
    /// </summary>
    public sealed class UniverseLayoutCache
    {
        // A reader can only land on a handful of visible sets, so this never fills up in
        // practice. I capped it anyway in case that ever widens, and the oldest entry goes
        // first when it does.
        private const int Capacity = 16;

        private readonly Dictionary<string, EntityGraph> _cache = new(StringComparer.Ordinal);
        private readonly Queue<string> _order = new();

        /// <summary>
        /// Node ids in the order BuildFullGraph fixed them, then the edges. No id has a newline
        /// in it, so nothing blurs together. I key on the edges too because a connection can be
        /// spoiler-gated on its own.
        /// </summary>
        public static string KeyFor(EntityGraph graph)
        {
            var builder = new StringBuilder();
            foreach (var node in graph.Nodes)
            {
                builder.Append(node.Id).Append('\n');
            }

            // No id has a null in it either, so I use one to keep the two lists from bleeding
            // into each other.
            builder.Append('\0');

            foreach (var edge in graph.Edges)
            {
                builder.Append(edge.SourceId).Append('|').Append(edge.TargetId).Append('\n');
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gives you the settled graph, running the layout first if I haven't seen this key
        /// before. I keep my own copy, so nobody downstream can nudge a node and wreck it for
        /// the next visitor.
        /// </summary>
        public EntityGraph GetOrAdd(string key, EntityGraph graph, Action<EntityGraph> layout)
        {
            if (_cache.TryGetValue(key, out var settled))
            {
                return Copy(settled);
            }

            layout(graph);
            _cache[key] = Copy(graph);
            _order.Enqueue(key);

            if (_order.Count > Capacity)
            {
                _cache.Remove(_order.Dequeue());
            }

            return graph;
        }

        // Node coordinates are mutable, so the copy gets its own and the stored one stays put.
        // Edges are immutable records, so I share that list rather than rebuild it. ForceX and
        // ForceY are just sim scratch, not worth carrying over.
        private static EntityGraph Copy(EntityGraph source)
        {
            var copy = new EntityGraph();
            foreach (var node in source.Nodes)
            {
                copy.Nodes.Add(new GraphNode
                {
                    Id = node.Id,
                    Name = node.Name,
                    ShortDescription = node.ShortDescription,
                    Category = node.Category,
                    IsCenter = node.IsCenter,
                    X = node.X,
                    Y = node.Y,
                });
            }
            copy.Edges.AddRange(source.Edges);
            return copy;
        }
    }
}
