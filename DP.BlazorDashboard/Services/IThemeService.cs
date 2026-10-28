namespace DP.BlazorDashboard.Services;

/// <summary>
/// Interface for theme management in the dashboard.
/// Implement this interface to provide custom theme handling.
/// </summary>
public interface IThemeService
{
    /// <summary>
    /// Gets whether dark mode is currently enabled.
    /// </summary>
    bool IsDarkMode { get; }

    /// <summary>
    /// Sets the dark mode state.
    /// </summary>
    /// <param name="isDarkMode">True to enable dark mode, false for light mode.</param>
    void SetDarkMode(bool isDarkMode);

    /// <summary>
    /// Event raised when the theme changes.
    /// </summary>
    event Action? OnChange;
}
