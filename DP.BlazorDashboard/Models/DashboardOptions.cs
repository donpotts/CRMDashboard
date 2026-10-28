namespace DP.BlazorDashboard.Models;

/// <summary>
/// Configuration options for the Dashboard component.
/// </summary>
public class DashboardOptions
{
    /// <summary>
    /// Whether to show the Add Card button. Default: true.
    /// </summary>
    public bool ShowAddButton { get; set; } = true;

    /// <summary>
    /// Whether to show the Reset Layout button. Default: true.
    /// </summary>
    public bool ShowResetButton { get; set; } = true;

    /// <summary>
    /// Whether cards can be deleted. Default: true.
    /// </summary>
    public bool AllowDelete { get; set; } = true;

    /// <summary>
    /// Whether cards can be moved. Default: true.
    /// </summary>
    public bool AllowMove { get; set; } = true;

    /// <summary>
    /// Whether cards can be resized. Default: true.
    /// </summary>
    public bool AllowResize { get; set; } = true;

    /// <summary>
    /// Whether to persist layout to storage. Default: true.
    /// </summary>
    public bool PersistLayout { get; set; } = true;

    /// <summary>
    /// Whether to automatically render charts for cards with ChartConfig. Default: true.
    /// </summary>
    public bool AutoRenderCharts { get; set; } = true;

    /// <summary>
    /// Delay in milliseconds before rendering charts (for DOM readiness). Default: 100.
    /// </summary>
    public int ChartRenderDelayMs { get; set; } = 100;

    /// <summary>
    /// GridStack configuration options.
    /// </summary>
    public GridOptions Grid { get; set; } = new();
}

/// <summary>
/// GridStack-specific configuration options.
/// </summary>
public class GridOptions
{
    /// <summary>
    /// Cell height in pixels. Default: 70.
    /// </summary>
    public int CellHeight { get; set; } = 70;

    /// <summary>
    /// Margin between cards in pixels. Default: 10.
    /// </summary>
    public int Margin { get; set; } = 10;

    /// <summary>
    /// Number of columns in the grid. Default: 12.
    /// </summary>
    public int Column { get; set; } = 12;

    /// <summary>
    /// Whether to enable float mode. Default: true.
    /// </summary>
    public bool Float { get; set; } = true;

    /// <summary>
    /// Whether to enable animations. Default: true.
    /// </summary>
    public bool Animate { get; set; } = true;

    /// <summary>
    /// Default width for new cards. Default: 4.
    /// </summary>
    public int DefaultCardWidth { get; set; } = 4;

    /// <summary>
    /// Default height for new cards. Default: 5.
    /// </summary>
    public int DefaultCardHeight { get; set; } = 5;
}
