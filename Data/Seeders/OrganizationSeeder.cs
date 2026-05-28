using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class OrganizationSeeder
    {
        public static List<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                // -- COPY THIS BLOCK FOR EACH NEW ORGANIZATION --
                new Organization
                {
                    Id = "org_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    Headquarters = "",
                    PrimaryDirective = ""
                },
                // -- END BLOCK --
            };
        }
    }
}