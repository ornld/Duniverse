using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// Represents religious, philosophical, or systemic belief structures.
    /// </summary>
    public class TheologicalSystem : DuneEntity
    {
        /// <summary>
        /// A summary of the central dogmas or philosophical tenets.
        /// </summary>
        public string? CoreTenets { get; set; }

        /// <summary>
        /// The primary sacred texts or foundational documents associated with the system.
        /// </summary>
        public List<string> FoundationalTexts { get; set; } = new List<string>();
    }
}