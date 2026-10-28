using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using DP.BlazorDashboard;
using SampleDashboard;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register MudBlazor services
builder.Services.AddMudServices();

// Register DP.BlazorDashboard services
builder.Services.AddBlazorDashboard(options =>
{
    options.ShowAddButton = true;
    options.ShowResetButton = true;
    options.AutoRenderCharts = true;
    options.Grid.CellHeight = 70;
});

await builder.Build().RunAsync();
