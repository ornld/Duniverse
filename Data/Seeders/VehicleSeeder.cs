using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class VehicleSeeder
    {
        public static List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                // -- COPY THIS BLOCK FOR EACH NEW VEHICLE --
                new Vehicle
                {
                    Id = "vehicle_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    OperatingEnvironment = "",
                    Capacity = ""
                },
                // -- END BLOCK --
            };
        }
    }
}