using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class DisciplineSeeder
    {
        public static List<Discipline> GetDisciplines()
        {
            return new List<Discipline>
            {
                // -- COPY THIS BLOCK FOR EACH NEW DISCIPLINE --
                new Discipline
                {
                    Id = "disc_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    Requirements = "",
                    Mechanics = ""
                },
                // -- END BLOCK --
            };
        }
    }
}