using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using DP.BlazorDashboard;
using DashboardDemo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Step 1: Register MudBlazor
builder.Services.AddMudServices();

// Step 2: Register DP.BlazorDashboard
builder.Services.AddBlazorDashboard();

await builder.Build().RunAsync();
