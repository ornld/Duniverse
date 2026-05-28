using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class TheologicalSystemSeeder
    {
        public static List<TheologicalSystem> GetTheologicalSystems()
        {
            return new List<TheologicalSystem>
            {
                // -- COPY THIS BLOCK FOR EACH NEW SYSTEM --
                new TheologicalSystem
                {
                    Id = "theo_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    CoreTenets = "",
                    FoundationalTexts = new List<string>()
                },
                // -- END BLOCK --
            };
        }
    }
}