using Duniverse.Models;
using Duniverse.Web.Services;

namespace Duniverse.Tests
{
    /// <summary>
    /// The cache exists so a settled web is drawn once. These hold the two promises that
    /// makes safe: the same records settle identically, and one graph never hands back
    /// another's positions.
    /// </summary>
    public sealed class GraphLayoutCacheTests
    {
        // A tiny web whose center is named, so a wrong cache hit shows up as a wrong middle.
        private static EntityGraph GraphOf(string centerId, params string[] ids)
        {
            var graph = new EntityGraph();
            foreach (var id in ids)
            {
                graph.Nodes.Add(new GraphNode
                {
                    Id = id,
                    Name = id,
                    ShortDescription = id,
                    Category = "personas",
                    IsCenter = id == centerId,
                });
            }

            for (int i = 1; i < ids.Length; i++)
            {
                graph.Edges.Add(new GraphEdge(ids[0], ids[i]));
            }

            return graph;
        }

        // Stands in for the force sim: deterministic, and it counts its own runs.
        private static Action<EntityGraph> Spread(Action? onRun = null) => graph =>
        {
            onRun?.Invoke();
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                graph.Nodes[i].X = 10 * i;
                graph.Nodes[i].Y = 20 * i;
            }
        };

        [Fact]
        public void TheSecondVisitReusesTheFirstLayout()
        {
            var cache = new GraphLayoutCache();
            int runs = 0;

            var first = GraphOf("a", "a", "b", "c");
            cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a", first), first, Spread(() => runs++));

            var second = GraphOf("a", "a", "b", "c");
            var settled = cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a", second), second, Spread(() => runs++));

            Assert.Equal(1, runs);
            Assert.Equal(20, settled.Nodes[2].X);
        }

        [Fact]
        public void TwoRecordsSharingANodeSetKeepTheirOwnCenter()
        {
            // Without the center in the key these collide: same ids, same edge, and the
            // stored copy carries IsCenter, so one record would draw the other's middle.
            var cache = new GraphLayoutCache();

            var pair = GraphOf("a", "a", "b");
            cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a", pair), pair, Spread());

            var mirrored = GraphOf("b", "a", "b");
            var settled = cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:b", mirrored), mirrored, Spread());

            Assert.Equal("b", settled.Nodes.Single(node => node.IsCenter).Id);
        }

        [Fact]
        public void TheConstellationAndARecordWebNeverShareAnEntry()
        {
            var cache = new GraphLayoutCache();
            int runs = 0;

            var web = GraphOf("a", "a", "b");
            cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a:760x460", web), web, Spread(() => runs++));

            var constellation = GraphOf("a", "a", "b");
            cache.GetOrAdd(GraphLayoutCache.KeyFor("universe:1600x850", constellation), constellation, Spread(() => runs++));

            Assert.Equal(2, runs);
        }

        [Fact]
        public void NudgingAReturnedNodeLeavesTheStoredLayoutAlone()
        {
            var cache = new GraphLayoutCache();

            var first = GraphOf("a", "a", "b");
            var handed = cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a", first), first, Spread());
            handed.Nodes[1].X = -999;

            var again = GraphOf("a", "a", "b");
            var settled = cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a", again), again, Spread());

            Assert.Equal(10, settled.Nodes[1].X);
        }

        [Fact]
        public void AGatedConnectionCountsAsADifferentWeb()
        {
            // Nodes alone are not the key. A reader who unlocks one more connection between
            // the same records has to get a fresh layout, not the older shape.
            var cache = new GraphLayoutCache();
            int runs = 0;

            var sparse = GraphOf("a", "a", "b", "c");
            cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a", sparse), sparse, Spread(() => runs++));

            var linked = GraphOf("a", "a", "b", "c");
            linked.Edges.Add(new GraphEdge("b", "c"));
            cache.GetOrAdd(GraphLayoutCache.KeyFor("ego:a", linked), linked, Spread(() => runs++));

            Assert.Equal(2, runs);
        }
    }
}
