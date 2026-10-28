# COPILOT.md

This file provides guidance to GitHub Copilot when working with code in this repository.

## Build and Run Commands

```powershell
# Run the application (from repository root)
dotnet run --project CRMDashboard/CRMDashboard.csproj

# Build the solution
dotnet build CRMDashboard.sln

# Build in release mode
dotnet build CRMDashboard.sln -c Release

# Create NuGet package for DP.BlazorDashboard
dotnet pack DP.BlazorDashboard/DP.BlazorDashboard.csproj -c Release
```

The app runs at https://localhost:7285 by default.

## Architecture Overview

This is a **Blazor WebAssembly** CRM dashboard application using **MudBlazor** for UI components.

### Solution Structure

The solution contains two projects:

1. **CRMDashboard** - The main Blazor WebAssembly application (net9.0)
   - Contains the CRM dashboard page with chart and KPI card configurations
   - Uses the reusable dashboard component from DP.BlazorDashboard

2. **DP.BlazorDashboard** - A reusable NuGet-ready Razor Class Library (net8.0/net9.0)
   - Multi-targets net8.0 and net9.0
   - Supports MudBlazor 7.x, 8.x, 9.x+
   - Provides batteries-included dashboard with automatic chart rendering

## DP.BlazorDashboard Library

### Setup (Consumer)

```csharp
// Program.cs
builder.Services.AddBlazorDashboard();

// Or with configuration:
builder.Services.AddBlazorDashboard(options =>
{
    options.AutoRenderCharts = true;
    options.Grid.CellHeight = 70;
});
```

### Dashboard Component Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `StorageKey` | string | Key for localStorage persistence |
| `InitialLayoutFactory` | Func<List<DashboardCard>> | Returns initial card layout |
| `CardRenderer` | RenderFragment<DashboardCard>? | Optional custom card renderer |
| `Options` | DashboardOptions? | Configuration options |
| `OnLayoutChanged` | EventCallback | Fired on layout changes |
| `OnCardAdded` | EventCallback<DashboardCard> | Fired when card added |
| `OnCardDeleted` | EventCallback<DashboardCard> | Fired when card deleted |

### Auto Chart Rendering

Cards with `ChartConfig` set are rendered automatically - no manual JS interop needed:

```csharp
new DashboardCard
{
    Id = "sales-chart",
    Title = "Sales",
    ChartConfig = new ChartConfig
    {
        Type = "line", // line, bar, doughnut, pie, radar, polarArea, scatter
        Labels = new List<string> { "Jan", "Feb", "Mar" },
        Datasets = new List<ChartDataset> { ... }
    }
}
```

### Key Files

**Services** (`DP.BlazorDashboard/Services/`):
- `IThemeService` / `ThemeService` - Dark/light mode management
- `IDashboardStorageService` / `DashboardStorageService` - Layout persistence
- `ChartService` - Chart.js rendering via JS interop

**Models** (`DP.BlazorDashboard/Models/`):
- `DashboardCard` - Card with position (X,Y,W,H), ChartConfig, MinW/MaxW/MinH/MaxH, Locked
- `DashboardOptions` - ShowAddButton, AllowDelete, AutoRenderCharts, Grid settings
- `GridOptions` - CellHeight, Margin, Column, DefaultCardWidth/Height

**Components** (`DP.BlazorDashboard/Components/`):
- `Dashboard.razor` - Main component
- `ChartCard.razor` - Built-in chart renderer
- `ConfirmDeleteDialog.razor` - Delete confirmation

**Extensions** (`DP.BlazorDashboard/Extensions/`):
- `ServiceCollectionExtensions.cs` - `AddBlazorDashboard()` methods

### JS Interop

- **dashboard-manager.js** - GridStack.js initialization with configurable options
- **chart-renderer.js** - Chart.js wrapper with MudBlazor theme-aware colors

## Third-Party Libraries

- **MudBlazor** (7.0.0+) - Material Design component library
- **GridStack.js** (9.3.0) - Drag-and-drop grid layout
- **Chart.js** (4.4.0) - Interactive charts
- **Font Awesome** (6.4.2) - Icons

## Copilot Guidelines

When assisting with this codebase:

- **Blazor conventions**: Use Razor component syntax, `@code` blocks, and proper parameter binding
- **MudBlazor**: Prefer MudBlazor components (`MudCard`, `MudButton`, etc.) over raw HTML
- **Dependency Injection**: Services are registered via `AddBlazorDashboard()` extension method
- **JS Interop**: Use `IJSRuntime` for JavaScript calls; existing interop is in `wwwroot/js/`
- **Async patterns**: Use `async/await` consistently for all async operations
- **Nullable references**: Project uses nullable reference types - handle nulls appropriately
