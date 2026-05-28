using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class HouseSeeder
    {
        public static List<House> GetHouses()
        {
            return new List<House>
            {
                // -- COPY THIS BLOCK FOR EACH NEW HOUSE --
                new House
                {
                    Id = "house_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    Sigil = "",
                    Motto = "",
                    HistoricalRivalries = new List<string>()
                },
                // -- END BLOCK --
            };
        }
    }
}