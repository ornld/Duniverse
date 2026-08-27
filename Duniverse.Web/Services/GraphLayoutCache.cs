using System;
using System.Collections.Generic;
using System.Text;
using Duniverse.Models;

namespace Duniverse.Web.Services
{
    /// <summary>
    /// I don't want the force sim rerunning on every visit, so I keep where a graph
    /// settled. The records are the key, so nobody sees anyone they haven't unlocked.
    /// The constellation and the record webs both draw from here.
    /// </summary>
    public sealed class GraphLayoutCache
    {
        // The constellation only has a handful of visible sets, but a reader can open any
        // record, so the record webs need the deeper shelf. The oldest entry goes first.
        private const int Capacity = 48;

        private readonly Dictionary<string, EntityGraph> _cache = new(StringComparer.Ordinal);
        private readonly Queue<string> _order = new();

        /// <summary>
        /// Node ids in the order the builder fixed them, then the edges. No id has a newline
        /// in it, so nothing blurs together. I key on the edges too because a connection can
        /// be spoiler-gated on its own.
        /// </summary>
        /// <param name="scope">What drew this and at what size. A record web carries its own
        /// center here: two records can share a node set, and the center is drawn differently,
        /// so without it one web could hand back the other's middle.</param>
        public static string KeyFor(string scope, EntityGraph graph)
        {
            var builder = new StringBuilder();
            builder.Append(scope).Append('\0');
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
