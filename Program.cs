using System;
using System.Linq;
using Duniverse.Services;
using Duniverse.Data.Seeders;
using Duniverse.Models;

namespace Duniverse
{
    class Program
    {
        private const string DividerLine = "----------------------------------------------------------------";

        static void Main(string[] args)
        {
            PrintBootBanner();

            var registry = new EntityRegistry();

            var artifacts = ArtifactSeeder.GetArtifacts();
            var disciplines = DisciplineSeeder.GetDisciplines();
            var personas = PersonaSeeder.GetPersonas();
            var worlds = WorldSeeder.GetWorlds();
            var houses = HouseSeeder.GetHouses();
            var organizations = OrganizationSeeder.GetOrganizations();
            var vehicles = VehicleSeeder.GetVehicles();
            var theologicalSystems = TheologicalSystemSeeder.GetTheologicalSystems();
            var historicalEvents = HistoricalEventSeeder.GetHistoricalEvents();
            var floraFaunas = FloraFaunaSeeder.GetFloraFaunas();

            registry.RegisterEntities(artifacts);
            registry.RegisterEntities(disciplines);
            registry.RegisterEntities(personas);
            registry.RegisterEntities(worlds);
            registry.RegisterEntities(houses);
            registry.RegisterEntities(organizations);
            registry.RegisterEntities(vehicles);
            registry.RegisterEntities(theologicalSystems);
            registry.RegisterEntities(historicalEvents);
            registry.RegisterEntities(floraFaunas);

            int totalRecords = artifacts.Count + disciplines.Count + personas.Count + worlds.Count
                + houses.Count + organizations.Count + vehicles.Count + theologicalSystems.Count
                + historicalEvents.Count + floraFaunas.Count;
            const int categoryCount = 10;

            Console.Clear();
            PrintReadyBanner(totalRecords, categoryCount);

            bool isRunning = true;
            while (isRunning)
            {
                PrintQueryHeader();

                string searchInput = Console.ReadLine()?.Trim().ToLower();

                if (searchInput == "exit")
                {
                    isRunning = false;
                    PrintExitBanner();
                    continue;
                }

                if (string.IsNullOrEmpty(searchInput))
                {
                    Console.WriteLine("\nPlease enter a valid ID or name.\n");
                    continue;
                }

                // Try an exact ID match first; if that misses, fall back to a name search;
                // if that also misses, fall back to fuzzy "did you mean" suggestions
                var primaryEntity = registry.GetEntity(searchInput);
                if (primaryEntity == null)
                {
                    var nameMatches = registry.SearchByName(searchInput).ToList();
                    if (nameMatches.Count > 1)
                    {
                        Console.WriteLine($"\n{nameMatches.Count} records match '{searchInput}'. Refine your query using one of the IDs below:\n");
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
                    else
                    {
                        var suggestions = registry.FindClosestByName(searchInput);
                        if (suggestions.Count == 1)
                        {
                            var suggestion = suggestions[0];
                            Console.WriteLine($"\nNo exact match for '{searchInput}' — did you mean '{suggestion.Name}'? Showing that entry.");
                            primaryEntity = suggestion;
                            searchInput = suggestion.Id.ToLower();
                        }
                        else if (suggestions.Count > 1)
                        {
                            Console.WriteLine($"\nNo exact match for '{searchInput}'. Did you mean one of these?\n");
                            foreach (var suggestion in suggestions)
                            {
                                Console.WriteLine($" * {suggestion.Name} -> {suggestion.Id}");
                            }
                            Console.WriteLine("\nPress Enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                    }
                }

                Console.WriteLine($"\n{DividerLine}");
                Console.WriteLine($" QUERY RESULTS: '{searchInput}'");
                Console.WriteLine($"{DividerLine}\n");

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

                if (primaryEntity != null)
                {
                    Console.WriteLine(DividerLine);
                    Console.WriteLine(" Connected relationships throughout the Duniverse:");
                    Console.WriteLine($"{DividerLine}\n");
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
                    Console.WriteLine("No matching records found. Verify the ID or name and try again.\n");
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        /// <summary>
        /// Prints the splash banner shown while the archive is still initializing.
        /// </summary>
        private static void PrintBootBanner()
        {
            Console.WriteLine(DividerLine);
            Console.WriteLine(" DUNIVERSE ARCHIVES  |  Imperial Records Division");
            Console.WriteLine(DividerLine);
            Console.WriteLine("Initializing archive index...");
        }

        /// <summary>
        /// Prints the readiness summary once every seeder has been registered.
        /// </summary>
        private static void PrintReadyBanner(int totalRecords, int categoryCount)
        {
            Console.WriteLine(DividerLine);
            Console.WriteLine(" DUNIVERSE ARCHIVES  |  Imperial Records Division");
            Console.WriteLine(DividerLine);
            Console.WriteLine($" Archive index initialized: {totalRecords} records across {categoryCount} categories.");
            Console.WriteLine(" System ready. Awaiting query.\n");
        }

        /// <summary>
        /// Prints the recurring query prompt shown at the top of every search.
        /// </summary>
        private static void PrintQueryHeader()
        {
            Console.WriteLine(DividerLine);
            Console.WriteLine(" DUNIVERSE ARCHIVES  |  Query Terminal");
            Console.WriteLine(" Welcome to the records of the Chapterhouse Keep.");
            Console.WriteLine(" All information preserved and maintained by the Order of the Bene Gesserit.");
            Console.WriteLine(DividerLine);
            Console.WriteLine(" Enter an Entity ID or Name to retrieve related records.");
            Console.WriteLine(" Type 'exit' to close the session.");
            Console.Write("\nQuery > ");
        }

        /// <summary>
        /// Prints the closing banner shown when the user ends the session.
        /// </summary>
        private static void PrintExitBanner()
        {
            Console.WriteLine(DividerLine);
            Console.WriteLine(" Closing session. All records secured.");
            Console.WriteLine(" Thank you for consulting the Chapterhouse Archives.");
            Console.WriteLine(DividerLine);
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
