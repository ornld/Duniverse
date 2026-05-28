using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class PersonaSeeder
    {
        public static List<Persona> GetPersonas()
        {
            return new List<Persona>
            {
                /* -- COPY THIS BLOCK FOR EACH NEW PERSONA --
                new Persona
                {
                    Id = "char_unique_id",
                    Name = "",
                    ShortDescription = "",
                    DetailedHistory = "",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    Affiliation = "",
                    Role = "",
                    NotableQuotes = new List<string>()
                },
                */
                new Persona
                {
                    Id = "char_PaulAtreides",
                    Name = "Paul Atreides",
                    ShortDescription = "The prophesied Kwisatz Haderach and a central figure in the Dune saga.",
                    DetailedHistory = "Paul Atreides is the son of Duke Leto Atreides and Lady Jessica. He is the rightful heir to the throne of Arrakis and the chosen one prophesied in the Bene Gesserit sisterhood.",
                    ImagePath = "",
                    RelatedEntityIds = new List<string>(),
                    
                    Affiliation = "House Atreides",
                    Role = "Chosen One",
                    NotableQuotes = new List<string>()
                },
            };
        }
    }
}
                    