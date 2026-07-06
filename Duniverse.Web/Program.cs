using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Duniverse.Web;
using Duniverse.Web.Services;
using Duniverse.Data;
using Duniverse.Data.Seeders;
using Duniverse.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton(BuildRegistry());
builder.Services.AddSingleton<GraphLayoutService>();
builder.Services.AddScoped<SpoilerSettings>();

await builder.Build().RunAsync();

static EntityRegistry BuildRegistry()
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

    // Stamp spoiler tiers on the entities that later books introduce, so the optional spoiler
    // gate has something to filter against. Everything unlisted stays safe-from-Dune.
    SpoilerTierMap.Apply(registry);

    return registry;
}
