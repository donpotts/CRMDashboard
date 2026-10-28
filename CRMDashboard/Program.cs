using CRMDashboard;
using MudBlazor.Services;
using DP.BlazorDashboard;
using DP.BlazorDashboard.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register DP.BlazorDashboard services with global configuration options
builder.Services.AddBlazorDashboard(options =>
{
    // Dashboard behavior options
    options.ShowAddButton = true;
    options.ShowResetButton = true;
    options.AllowDelete = true;
    options.AllowMove = true;
    options.AllowResize = true;
    options.PersistLayout = true;
    options.AutoRenderCharts = true;
    options.ChartRenderDelayMs = 100;

    // Grid layout options
    options.Grid.CellHeight = 70;
    options.Grid.Margin = 10;
    options.Grid.Column = 12;
    options.Grid.Float = true;
    options.Grid.Animate = true;
    options.Grid.DefaultCardWidth = 4;
    options.Grid.DefaultCardHeight = 4;
});

builder.Services.AddMudServices();

await builder.Build().RunAsync();
