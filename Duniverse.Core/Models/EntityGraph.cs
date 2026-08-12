using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// The nodes and edges of a laid-out relationship graph, ready to draw as SVG. I named it
    /// apart from the RelationshipGraph Razor component that renders it, so the two don't
    /// collide in scope.
    /// </summary>
    public class EntityGraph
    {
        public List<GraphNode> Nodes { get; } = new();
        public List<GraphEdge> Edges { get; } = new();
    }
}
