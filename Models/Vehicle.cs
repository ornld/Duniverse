namespace Duniverse.Models
{
    /// <summary>
    /// Represents larger mechanical entities utilized for transport or warfare.
    /// </summary>
    public class Vehicle : DuneEntity
    {
        /// <summary>
        /// The environment in which the vehicle operates (e.g., Space, Atmosphere, Desert).
        /// </summary>
        public string? OperatingEnvironment { get; set; }

        /// <summary>
        /// The maximum number of individuals or cargo tonnage the vehicle can carry.
        /// </summary>
        public string? Capacity { get; set; }
    }
}