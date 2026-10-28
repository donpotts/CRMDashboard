namespace DP.BlazorDashboard.Services;

/// <summary>
/// Default implementation of IThemeService for simple dark/light mode management.
/// </summary>
public class ThemeService : IThemeService
{
    private bool _isDarkMode;

    /// <inheritdoc />
    public bool IsDarkMode => _isDarkMode;

    /// <inheritdoc />
    public void SetDarkMode(bool isDarkMode)
    {
        if (_isDarkMode != isDarkMode)
        {
            _isDarkMode = isDarkMode;
            OnChange?.Invoke();
        }
    }

    /// <inheritdoc />
    public event Action? OnChange;
}
