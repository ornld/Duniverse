using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class WorldSeeder
    {
        public static List<World> GetWorlds()
        {
            return new List<World>
            {
                // -- COPY THIS BLOCK FOR EACH NEW WORLD --
                new World
                {
                    Id = "world_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    EnvironmentalData = "",
                    RulingHouse = "",
                    LocalCustoms = new List<string>()
                },
                // -- END BLOCK --
            };
        }
    }
}