namespace Duniverse.Models
{
    /// <summary>
    /// One point in a relationship graph: the entity plus wherever GraphLayoutService settled
    /// it. The coordinates are mutable since force-directed layout is iterative, so a node
    /// drifts into place over many small nudges instead of landing once.
    /// </summary>
    public class GraphNode
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public required string ShortDescription { get; init; }

        /// <summary>
        /// The category slug (e.g. "personas", "houses") matching the site's existing
        /// /category/{slug} routes, used to color-code nodes and link back into the archive.
        /// </summary>
        public required string Category { get; init; }

        /// <summary>
        /// True for the entity the graph is centered on. Rendered larger and brighter so the
        /// viewer always has an anchor point while exploring outward.
        /// </summary>
        public bool IsCenter { get; init; }

        public double X { get; set; }
        public double Y { get; set; }

        /// <summary>Running force accumulator for the current simulation step.</summary>
        internal double ForceX { get; set; }
        internal double ForceY { get; set; }
    }
}
