using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Duniverse.Web;
using Duniverse.Web.Services;
using Duniverse.Data;
using Duniverse.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton(RegistryFactory.CreateSeeded());
builder.Services.AddSingleton<GraphLayoutService>();
builder.Services.AddSingleton<UniverseLayoutCache>();
builder.Services.AddSingleton<PathFinderService>();
builder.Services.AddScoped<SpoilerSettings>();

await builder.Build().RunAsync();
