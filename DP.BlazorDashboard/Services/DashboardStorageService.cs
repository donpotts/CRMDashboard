using Microsoft.JSInterop;
using System.Text.Json;
using DP.BlazorDashboard.Models;

namespace DP.BlazorDashboard.Services;

/// <summary>
/// Default implementation of IDashboardStorageService using browser localStorage.
/// </summary>
public class DashboardStorageService : IDashboardStorageService
{
    private readonly IJSRuntime _jsRuntime;

    /// <summary>
    /// Initializes a new instance of the DashboardStorageService.
    /// </summary>
    /// <param name="jsRuntime">The JavaScript runtime for interop.</param>
    public DashboardStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <inheritdoc />
    public async Task<List<DashboardCard>> LoadLayoutAsync(string storageKey)
    {
        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", storageKey);
            if (!string.IsNullOrEmpty(json))
            {
                return JsonSerializer.Deserialize<List<DashboardCard>>(json) ?? new List<DashboardCard>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading layout: {ex.Message}");
        }

        return new List<DashboardCard>();
    }

    /// <inheritdoc />
    public async Task SaveLayoutAsync(string storageKey, List<DashboardCard> cards)
    {
        try
        {
            var json = JsonSerializer.Serialize(cards);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", storageKey, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving layout: {ex.Message}");
        }
    }

    /// <inheritdoc />
    public async Task ClearLayoutAsync(string storageKey)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", storageKey);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error clearing layout: {ex.Message}");
        }
    }
}
