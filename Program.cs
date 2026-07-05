using System;
using System.Linq;
using Duniverse.Services;
using Duniverse.Data.Seeders;
using Duniverse.Models;

namespace Duniverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Booting up the Duniverse Databanks...");

            var registry = new EntityRegistry();

            registry.RegisterEntities(ArtifactSeeder.GetArtifacts());
            registry.RegisterEntities(DisciplineSeeder.GetDisciplines());
            registry.RegisterEntities(PersonaSeeder.GetPersonas());
            registry.RegisterEntities(WorldSeeder.GetWorlds());
            registry.RegisterEntities(HouseSeeder.GetHouses());
            registry.RegisterEntities(OrganizationSeeder.GetOrganizations());
            registry.RegisterEntities(VehicleSeeder.GetVehicles());
            registry.RegisterEntities(TheologicalSystemSeeder.GetTheologicalSystems());
            registry.RegisterEntities(HistoricalEventSeeder.GetHistoricalEvents());
            registry.RegisterEntities(FloraFaunaSeeder.GetFloraFaunas());

            Console.Clear();
            Console.WriteLine("Encyclopedia data loaded successfully!\n");

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("=====================================================");
                Console.WriteLine("               DUNIVERSE ENCYCLOPEDIA                ");
                Console.WriteLine("=====================================================");
                Console.WriteLine("Enter an Entity ID or Name to find related records.");
                Console.WriteLine("(Examples: char_PaulAtreides, Paul Atreides, org_BeneGesserit, Arrakis)");
                Console.WriteLine("Type 'exit' to close the databanks.");
                Console.Write("\nSearch > ");

                string searchInput = Console.ReadLine()?.Trim().ToLower();

                if (searchInput == "exit")
                {
                    isRunning = false;
                    Console.WriteLine("Shutting down...");
                    continue;
                }

                if (string.IsNullOrEmpty(searchInput))
                {
                    Console.WriteLine("\nPlease enter a valid ID or name.\n");
                    continue;
                }

                // Try an exact ID match first; if that misses, fall back to a name search
                var primaryEntity = registry.GetEntity(searchInput);
                if (primaryEntity == null)
                {
                    var nameMatches = registry.SearchByName(searchInput).ToList();
                    if (nameMatches.Count > 1)
                    {
                        Console.WriteLine($"\nMultiple entries match '{searchInput}'. Search again using one of these IDs:\n");
                        foreach (var match in nameMatches)
                        {
                            Console.WriteLine($" * {match.Name} -> {match.Id}");
                        }
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                    if (nameMatches.Count == 1)
                    {
                        primaryEntity = nameMatches[0];
                        searchInput = primaryEntity.Id.ToLower();
                    }
                }

                Console.WriteLine($"\n--- SEARCH RESULTS FOR: '{searchInput}' ---\n");

                bool foundRecords = false;

                // Show the primary entity's own detail first, if it exists
                if (primaryEntity != null)
                {
                    foundRecords = true;
                    Console.WriteLine($"[{primaryEntity.Name.ToUpper()}]");
                    Console.WriteLine($" {primaryEntity.ShortDescription}");
                    if (!string.IsNullOrEmpty(primaryEntity.DetailedHistory))
                    {
                        Console.WriteLine($" {primaryEntity.DetailedHistory}");
                    }

                    if (primaryEntity is House)
                    {
                        var rivals = registry.GetRivalHouses(searchInput).ToList();
                        if (rivals.Any())
                        {
                            Console.WriteLine($" Historical Rivalries: {string.Join(", ", rivals.Select(rival => rival.Name))}");
                        }
                    }

                    Console.WriteLine();
                }

                // Fetch all related entities of every category based on user input
                PrintRelated(registry.GetRelatedEntities<Persona>(searchInput), "PERSONAS", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<House>(searchInput), "HOUSES", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<Organization>(searchInput), "ORGANIZATIONS", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<World>(searchInput), "WORLDS & LOCATIONS", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<Artifact>(searchInput), "ARTIFACTS", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<Vehicle>(searchInput), "VEHICLES", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<Discipline>(searchInput), "DISCIPLINES", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<TheologicalSystem>(searchInput), "THEOLOGICAL SYSTEMS", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<HistoricalEvent>(searchInput), "HISTORICAL EVENTS", ref foundRecords);
                PrintRelated(registry.GetRelatedEntities<FloraFauna>(searchInput), "FLORA & FAUNA", ref foundRecords);

                if (!foundRecords)
                {
                    Console.WriteLine("No records found linked to that ID or name. Please check your spelling and try again.\n");
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        /// <summary>
        /// Prints a labeled section of related entities, if any were found.
        /// </summary>
        private static void PrintRelated<T>(System.Collections.Generic.IEnumerable<T> entities, string label, ref bool foundRecords) where T : DuneEntity
        {
            var results = entities.ToList();
            if (!results.Any())
            {
                return;
            }

            foundRecords = true;
            Console.WriteLine($"[{label}]");
            foreach (var entity in results)
            {
                Console.WriteLine($" * {entity.Name}: {entity.ShortDescription}");
            }
            Console.WriteLine();
        }
    }
}
