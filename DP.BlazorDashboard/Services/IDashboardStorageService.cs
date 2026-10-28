using DP.BlazorDashboard.Models;

namespace DP.BlazorDashboard.Services;

/// <summary>
/// Interface for dashboard layout persistence.
/// Implement this interface to provide custom storage (e.g., server-side, IndexedDB).
/// </summary>
public interface IDashboardStorageService
{
    /// <summary>
    /// Loads the dashboard layout from storage.
    /// </summary>
    /// <param name="storageKey">The unique key identifying the layout.</param>
    /// <returns>The list of dashboard cards, or empty list if not found.</returns>
    Task<List<DashboardCard>> LoadLayoutAsync(string storageKey);

    /// <summary>
    /// Saves the dashboard layout to storage.
    /// </summary>
    /// <param name="storageKey">The unique key identifying the layout.</param>
    /// <param name="cards">The cards to save.</param>
    Task SaveLayoutAsync(string storageKey, List<DashboardCard> cards);

    /// <summary>
    /// Clears the stored layout.
    /// </summary>
    /// <param name="storageKey">The unique key identifying the layout.</param>
    Task ClearLayoutAsync(string storageKey);
}
