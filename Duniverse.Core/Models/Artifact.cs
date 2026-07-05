namespace Duniverse.Models
{
    /// <summary>
    /// Represents personal equipment, gear, or physical objects.
    /// </summary>
    public class Artifact : DuneEntity
    {
        /// <summary>
        /// The primary materials used in the construction of the artifact.
        /// </summary>
        public string? PrimaryMaterial { get; set; }

        /// <summary>
        /// The intended use or mechanical function of the item.
        /// </summary>
        public string? Functionality { get; set; }
    }
}