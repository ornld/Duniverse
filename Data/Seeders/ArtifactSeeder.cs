using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class ArtifactSeeder
    {
        public static List<Artifact> GetArtifacts()
        {
            return new List<Artifact>
            {
                // -- COPY THIS BLOCK FOR EACH NEW ARTIFACT --
                new Artifact
                {
                    Id = "artifact_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    PrimaryMaterial = "",
                    Functionality = ""
                },
                // -- END BLOCK --
            };
        }
    }
}