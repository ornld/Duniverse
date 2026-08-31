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
builder.Services.AddSingleton<GraphLayoutCache>();
builder.Services.AddSingleton<PathFinderService>();
builder.Services.AddSingleton<MentatTrialService>();
builder.Services.AddScoped<SpoilerSettings>();
builder.Services.AddScoped<UnsealedRecords>();
builder.Services.AddScoped<LostPageSignal>();

await builder.Build().RunAsync();
