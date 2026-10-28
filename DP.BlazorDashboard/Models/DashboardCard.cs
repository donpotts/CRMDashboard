using System.Text.Json.Serialization;

namespace DP.BlazorDashboard.Models;

/// <summary>
/// Represents a card in the dashboard grid.
/// </summary>
public class DashboardCard
{
    /// <summary>
    /// Unique identifier for the card.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display title for the card header.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Card type identifier used for custom rendering.
    /// </summary>
    public string CardType { get; set; } = string.Empty;

    /// <summary>
    /// X position in the grid (0-based).
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Y position in the grid (0-based).
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Width in grid units.
    /// </summary>
    public int W { get; set; }

    /// <summary>
    /// Height in grid units.
    /// </summary>
    public int H { get; set; }

    /// <summary>
    /// Minimum width in grid units.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinW { get; set; }

    /// <summary>
    /// Maximum width in grid units.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxW { get; set; }

    /// <summary>
    /// Minimum height in grid units.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinH { get; set; }

    /// <summary>
    /// Maximum height in grid units.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxH { get; set; }

    /// <summary>
    /// Whether this card is locked (cannot move/resize).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Locked { get; set; }

    /// <summary>
    /// Chart configuration for cards that display charts.
    /// When set, the library will automatically render the chart.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartConfig? ChartConfig { get; set; }

    /// <summary>
    /// Custom data that can be attached to the card.
    /// Useful for passing data to custom card renderers.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Data { get; set; }

    /// <summary>
    /// CSS class to apply to the card.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CssClass { get; set; }
}

/// <summary>
/// Configuration for Chart.js charts.
/// </summary>
public class ChartConfig
{
    /// <summary>
    /// Chart type: line, bar, doughnut, pie, radar, polarArea, scatter.
    /// </summary>
    public string Type { get; set; } = "line";

    /// <summary>
    /// Labels for the chart axes.
    /// </summary>
    public List<string> Labels { get; set; } = new();

    /// <summary>
    /// Data series for the chart.
    /// </summary>
    public List<ChartDataset> Datasets { get; set; } = new();

    /// <summary>
    /// Chart options for customization.
    /// </summary>
    public ChartOptions? Options { get; set; }
}

/// <summary>
/// A dataset for Chart.js charts.
/// </summary>
public class ChartDataset
{
    /// <summary>
    /// Label for this dataset.
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Data points for this dataset.
    /// </summary>
    public List<double> Data { get; set; } = new();

    /// <summary>
    /// Border color for lines and bar outlines.
    /// </summary>
    public string? BorderColor { get; set; }

    /// <summary>
    /// Background color for fills and bars.
    /// </summary>
    public string? BackgroundColor { get; set; }

    /// <summary>
    /// For multi-color charts like doughnut, pie, polarArea.
    /// </summary>
    public List<string>? BackgroundColors { get; set; }

    /// <summary>
    /// Line tension for line charts (0 = straight, 0.4 = curved).
    /// </summary>
    public double? Tension { get; set; }

    /// <summary>
    /// Whether to fill under the line for line charts.
    /// </summary>
    public bool? Fill { get; set; }

    /// <summary>
    /// Border width in pixels.
    /// </summary>
    public int? BorderWidth { get; set; }
}

/// <summary>
/// Chart.js options configuration.
/// </summary>
public class ChartOptions
{
    /// <summary>
    /// Whether the chart should be responsive.
    /// </summary>
    public bool Responsive { get; set; } = true;

    /// <summary>
    /// Whether to maintain the aspect ratio.
    /// </summary>
    public bool MaintainAspectRatio { get; set; } = false;

    /// <summary>
    /// Legend configuration.
    /// </summary>
    public ChartLegend? Legend { get; set; }

    /// <summary>
    /// Scales configuration for axes.
    /// </summary>
    public Dictionary<string, object>? Scales { get; set; }
}

/// <summary>
/// Legend configuration for Chart.js.
/// </summary>
public class ChartLegend
{
    /// <summary>
    /// Position of the legend: top, bottom, left, right.
    /// </summary>
    public string Position { get; set; } = "top";

    /// <summary>
    /// Whether to display the legend.
    /// </summary>
    public bool Display { get; set; } = true;
}
