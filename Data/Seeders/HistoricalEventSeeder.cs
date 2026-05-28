using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class HistoricalEventSeeder
    {
        public static List<HistoricalEvent> GetHistoricalEvents()
        {
            return new List<HistoricalEvent>
            {
                // -- COPY THIS BLOCK FOR EACH NEW EVENT --
                new HistoricalEvent
                {
                    Id = "event_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    Timeframe = "",
                    LastingImpact = "",
                    InvolvedFactionsIds = new List<string>()
                },
                // -- END BLOCK --
            };
        }
    }
}