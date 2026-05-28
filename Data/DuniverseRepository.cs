using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data
{
    /// <summary>
    /// Acts as the central database manager for looking up encyclopedia entries.
    /// </summary>
    public class DuniverseRepository
    {
        private readonly Dictionary<string, DuneEntity> _encyclopedia;

        public DuniverseRepository()
        {
            // Call the separate seeder file to get our starting dictionary
            _encyclopedia = DataSeeder.GenerateInitialData();
        }

        /// <summary>
        /// Searches the dictionary for a specific entity using its ID.
        /// </summary>
        public DuneEntity? GetEntity(string id)
        {
            if (_encyclopedia.TryGetValue(id, out DuneEntity? entity))
            {
                return entity;
            }
            
            return null; 
        }
    }
}