using System;
using System.Collections.Generic;
using System.Text;
using Duniverse.Models;

namespace Duniverse.Web.Services
{
    /// <summary>
    /// Remembers where the /universe graph settled so a reader who leaves the page and comes
    /// back does not pay for the force-directed simulation again. MainLayout keys the page
    /// wrapper by URI, so every visit builds the component from scratch; without this cache each
    /// rebuild reruns the whole spring embedder, roughly sixteen thousand pairwise repulsions
    /// across two hundred and twenty iterations, interpreted, on the main thread. The layout is
    /// deterministic (nodes seed on a circle by index and nothing in the simulation draws on
    /// randomness), so a given set of visible records always settles the same way, which is what
    /// makes a stored result safe to hand back.
    ///
    /// The key is the ordered ids of the records actually in the graph, not the reader's spoiler
    /// preferences. BuildFullGraph already sorts entities by id, so the node order is the
    /// canonical visible set. Keying on that set rather than on Enabled, NovelProgress, and
    /// IncludeExpandedUniverse means the cache can never serve a layout containing a record the
    /// reader is not cleared to see, even if the filtering rules are rewritten later: two
    /// settings that admit exactly the same records fall on one entry, and any difference in the
    /// admitted records is a different key. The joined id string is itself the dictionary key
    /// rather than a numeric hash of it, so no hash collision can ever hand a reader someone
    /// else's universe, which on a spoiler site is the one mistake that has to be impossible.
    /// </summary>
    public sealed class UniverseLayoutCache
    {
        // A reader can reach only a handful of distinct visible sets: protection off is the whole
        // archive, and protection on is one of six novel tiers crossed with the Expanded Universe
        // toggle, several of which collapse onto the same set of records. The cap sits well above
        // that count so ordinary use never evicts, and exists only to bound memory if some later
        // control widens the space of reachable sets. Eviction is plain insertion-order FIFO,
        // which is all a space this small earns.
        private const int Capacity = 16;

        private readonly Dictionary<string, EntityGraph> _cache = new(StringComparer.Ordinal);
        private readonly Queue<string> _order = new();

        /// <summary>
        /// The cache key for a built but not yet laid-out graph: its node ids joined in the order
        /// BuildFullGraph fixed them. A newline cannot occur inside an id, so the join stays
        /// unambiguous and two different visible sets can never fold onto the same string.
        /// </summary>
        public static string KeyFor(EntityGraph graph)
        {
            var builder = new StringBuilder();
            foreach (var node in graph.Nodes)
            {
                builder.Append(node.Id).Append('\n');
            }
            return builder.ToString();
        }

        /// <summary>
        /// Returns the settled graph for <paramref name="key"/>. On a miss it runs
        /// <paramref name="layout"/> over <paramref name="graph"/>, which settles the nodes in
        /// place, then remembers a copy of the settled result and hands the caller back its own
        /// graph. On a hit the freshly built <paramref name="graph"/> is thrown away and a copy of
        /// the remembered positions stands in for it, so the simulation never runs. The remembered
        /// graph is the cache's alone either way: it is never a graph the caller built and never
        /// one the caller is given, so nothing downstream can shift a node in the stored layout
        /// and pass the damage to every later visitor of that spoiler state.
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

        // A node carries mutable coordinates, so the stored master and the graph in a caller's
        // hands are never the same object: whichever of the two is the copy gets its own GraphNode
        // instances with the settled positions carried across, and the master sits behind them
        // untouched. Edges are immutable records and the ids they hold never change, so the edge
        // list is shared rather than rebuilt. ForceX and ForceY are simulation scratch that means
        // nothing once a layout has finished, so they are left at their defaults instead of
        // copied.
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
