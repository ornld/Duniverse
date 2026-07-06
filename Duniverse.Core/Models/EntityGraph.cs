using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// The nodes and edges that make up a laid-out relationship graph, ready to be drawn as SVG.
    /// Named distinctly from the RelationshipGraph Razor component that renders it, so the two
    /// don't collide when both are in scope.
    /// </summary>
    public class EntityGraph
    {
        public List<GraphNode> Nodes { get; } = new();
        public List<GraphEdge> Edges { get; } = new();
    }
}
