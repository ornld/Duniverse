using Duniverse.Data.Seeders;
using Duniverse.Services;

namespace Duniverse.Data
{
    /// <summary>
    /// Builds the fully seeded EntityRegistry that every front end (console, web) starts from.
    /// Keeping the seeder list in one place means a new category only has to be wired up once,
    /// and every UI automatically gets the same records with the same spoiler tiers applied.
    /// </summary>
    public static class RegistryFactory
    {
        public static EntityRegistry CreateSeeded()
        {
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

            // Stamp spoiler tiers on the entities that later books introduce, so the optional
            // spoiler gate has something to filter against. Everything unlisted stays safe-from-Dune.
            SpoilerTierMap.Apply(registry);

            // Give connections their meaning: mother and son, betrayer and betrayed. Runs after
            // the seeders because it can add links between pairs no seeder recorded.
            RelationshipMap.Apply(registry);

            // Debug-only id check for the Bloodlines chart, so a typo there fails at startup.
            BloodlineMap.Validate(registry);

            return registry;
        }
    }
}
