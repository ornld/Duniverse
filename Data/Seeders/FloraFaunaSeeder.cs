using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class FloraFaunaSeeder
    {
        public static List<FloraFauna> GetFloraFaunas()
        {
            return new List<FloraFauna>
            {
                // -- COPY THIS BLOCK FOR EACH NEW FLORA/FAUNA --
                new FloraFauna
                {
                    Id = "florafauna_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    BiologicalClassification = "",
                    DerivedProducts = ""
                },
                // -- END BLOCK --
            };
        }
    }
}