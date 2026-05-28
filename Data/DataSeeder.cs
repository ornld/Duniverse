using System.Collections.Generic;
using Duniverse.Models;
using Duniverse.Data.Seeders;

namespace Duniverse.Data
{
    /// <summary>
    /// Responsible for compiling all data from individual category seeders into the master encyclopedia.
    /// </summary>
    public static class DataSeeder
    {
        /// <summary>
        /// Generates the initial dictionary by calling all category seeders.
        /// </summary>
        public static Dictionary<string, DuneEntity> GenerateInitialData()
        {
            Dictionary<string, DuneEntity> masterDictionary = new Dictionary<string, DuneEntity>();

            // Load all entities from their respective seeders
            LoadEntities(masterDictionary, PersonaSeeder.GetPersonas());
            LoadEntities(masterDictionary, WorldSeeder.GetWorlds());
            LoadEntities(masterDictionary, HouseSeeder.GetHouses());
            LoadEntities(masterDictionary, ArtifactSeeder.GetArtifacts());
            LoadEntities(masterDictionary, OrganizationSeeder.GetOrganizations());
            LoadEntities(masterDictionary, VehicleSeeder.GetVehicles());
            LoadEntities(masterDictionary, FloraFaunaSeeder.GetFloraFaunas());
            LoadEntities(masterDictionary, TheologicalSystemSeeder.GetTheologicalSystems());
            LoadEntities(masterDictionary, DisciplineSeeder.GetDisciplines());
            LoadEntities(masterDictionary, HistoricalEventSeeder.GetHistoricalEvents());

            // Relationship Mapping:
            // If you need to map relationships (e.g., adding an Artifact's ID to a Persona's RelatedEntityIds),
            // you can write a dedicated method to handle that logic here, after everything is loaded.

            return masterDictionary;
        }

        /// <summary>
        /// A helper method to efficiently load a list of entities into the master dictionary.
        /// </summary>
        private static void LoadEntities(Dictionary<string, DuneEntity> dictionary, IEnumerable<DuneEntity> entities)
        {
            // A safety check in case a seeder is empty or hasn't been fully written yet
            if (entities == null) return;

            foreach (DuneEntity entity in entities)
            {
                // TryAdd is a safe C# method. It ensures that if two seeders accidentally 
                // create an item with the exact same ID, the program won't crash.
                dictionary.TryAdd(entity.Id, entity);
            }
        }
    }
}