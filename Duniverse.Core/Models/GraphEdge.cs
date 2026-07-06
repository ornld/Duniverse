namespace Duniverse.Models
{
    /// <summary>
    /// An undirected connection between two nodes in a relationship graph. The Duniverse data
    /// model only ever records a relationship on one side, but visually a link between two
    /// entities has no direction, so the graph treats every edge as symmetric.
    /// </summary>
    public record GraphEdge(string SourceId, string TargetId);
}
