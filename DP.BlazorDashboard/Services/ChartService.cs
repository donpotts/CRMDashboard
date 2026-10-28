using Microsoft.JSInterop;
using DP.BlazorDashboard.Models;

namespace DP.BlazorDashboard.Services;

/// <summary>
/// Service for rendering and managing Chart.js charts.
/// </summary>
public class ChartService : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _chartModule;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the ChartService.
    /// </summary>
    /// <param name="jsRuntime">The JavaScript runtime for interop.</param>
    public ChartService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Ensures the chart module is loaded.
    /// </summary>
    private async Task EnsureModuleLoadedAsync()
    {
        if (_chartModule == null)
        {
            _chartModule = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                "import",
                "./_content/DP.BlazorDashboard/js/chart-renderer.js");
        }
    }

    /// <summary>
    /// Renders a chart in the specified canvas element.
    /// </summary>
    /// <param name="canvasId">The ID of the canvas element.</param>
    /// <param name="config">The chart configuration.</param>
    public async Task RenderChartAsync(string canvasId, ChartConfig config)
    {
        await EnsureModuleLoadedAsync();

        if (_chartModule != null)
        {
            await _chartModule.InvokeVoidAsync("renderChart", canvasId, config);
        }
    }

    /// <summary>
    /// Renders a chart for a specific card.
    /// </summary>
    /// <param name="cardId">The card ID (canvas ID will be {cardId}Canvas).</param>
    /// <param name="config">The chart configuration.</param>
    public async Task RenderChartByCardIdAsync(string cardId, ChartConfig config)
    {
        await RenderChartAsync($"{cardId}Canvas", config);
    }

    /// <summary>
    /// Checks if a canvas element exists in the DOM.
    /// </summary>
    /// <param name="canvasId">The ID of the canvas element.</param>
    /// <returns>True if the canvas exists, false otherwise.</returns>
    public async Task<bool> CanvasExistsAsync(string canvasId)
    {
        return await _jsRuntime.InvokeAsync<bool>(
            "eval",
            $"document.getElementById('{canvasId}') !== null");
    }

    /// <summary>
    /// Renders all charts for cards that have ChartConfig.
    /// </summary>
    /// <param name="cards">The dashboard cards.</param>
    /// <param name="retryDelayMs">Delay in milliseconds to wait for canvas elements.</param>
    public async Task RenderAllChartsAsync(IEnumerable<DashboardCard> cards, int retryDelayMs = 100)
    {
        await EnsureModuleLoadedAsync();

        // Initial delay to ensure DOM is ready
        await Task.Delay(retryDelayMs);

        foreach (var card in cards.Where(c => c.ChartConfig != null))
        {
            var canvasId = $"{card.Id}Canvas";

            if (await CanvasExistsAsync(canvasId))
            {
                await RenderChartAsync(canvasId, card.ChartConfig!);
            }
            else
            {
                // Retry after additional delay
                await Task.Delay(retryDelayMs);
                if (await CanvasExistsAsync(canvasId))
                {
                    await RenderChartAsync(canvasId, card.ChartConfig!);
                }
            }
        }
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        if (!_disposed && _chartModule != null)
        {
            try
            {
                await _chartModule.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
                // Ignore - browser already disconnected
            }
            _disposed = true;
        }
    }
}
