namespace Duniverse.Models
{
    /// <summary>
    /// An undirected connection between two nodes. My data only records a relationship on one
    /// side, but a line between two entities looks the same either way, so I treat every edge as
    /// symmetric.
    /// </summary>
    public record GraphEdge(string SourceId, string TargetId);
}
