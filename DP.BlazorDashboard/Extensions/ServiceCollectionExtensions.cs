using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using DP.BlazorDashboard.Models;
using DP.BlazorDashboard.Services;

namespace DP.BlazorDashboard;

/// <summary>
/// Extension methods for configuring DP.BlazorDashboard services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds DP.BlazorDashboard services AND MudBlazor services with default options.
    /// This is the simplest setup - just call this one method.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddBlazorDashboard(this IServiceCollection services)
    {
        return services.AddBlazorDashboard(_ => { });
    }

    /// <summary>
    /// Adds DP.BlazorDashboard services AND MudBlazor services with configuration.
    /// This is the simplest setup - just call this one method.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Action to configure dashboard options.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddBlazorDashboard(
        this IServiceCollection services,
        Action<DashboardOptions> configure)
    {
        // Register MudBlazor services automatically
        services.AddMudServices();

        // Register dashboard options
        var options = new DashboardOptions();
        configure(options);
        services.AddSingleton(options);

        // Register services with interfaces for flexibility
        services.AddScoped<IThemeService, ThemeService>();
        services.AddScoped<IDashboardStorageService, DashboardStorageService>();
        services.AddScoped<ChartService>();

        // Also register ThemeService directly for backward compatibility
        services.AddScoped(sp => (ThemeService)sp.GetRequiredService<IThemeService>());

        return services;
    }

    /// <summary>
    /// Adds DP.BlazorDashboard services with a custom theme service implementation.
    /// </summary>
    /// <typeparam name="TThemeService">Custom theme service type implementing IThemeService.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddBlazorDashboard<TThemeService>(
        this IServiceCollection services)
        where TThemeService : class, IThemeService
    {
        return services.AddBlazorDashboard<TThemeService>(_ => { });
    }

    /// <summary>
    /// Adds DP.BlazorDashboard services with a custom theme service implementation and configuration.
    /// </summary>
    /// <typeparam name="TThemeService">Custom theme service type implementing IThemeService.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Action to configure dashboard options.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddBlazorDashboard<TThemeService>(
        this IServiceCollection services,
        Action<DashboardOptions> configure)
        where TThemeService : class, IThemeService
    {
        var options = new DashboardOptions();
        configure(options);
        services.AddSingleton(options);

        services.AddScoped<IThemeService, TThemeService>();
        services.AddScoped<IDashboardStorageService, DashboardStorageService>();
        services.AddScoped<ChartService>();

        return services;
    }

    /// <summary>
    /// Adds DP.BlazorDashboard services with a custom storage implementation.
    /// </summary>
    /// <typeparam name="TStorageService">Custom storage service type implementing IDashboardStorageService.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddBlazorDashboardWithCustomStorage<TStorageService>(
        this IServiceCollection services)
        where TStorageService : class, IDashboardStorageService
    {
        return services.AddBlazorDashboardWithCustomStorage<TStorageService>(_ => { });
    }

    /// <summary>
    /// Adds DP.BlazorDashboard services with a custom storage implementation and configuration.
    /// </summary>
    /// <typeparam name="TStorageService">Custom storage service type implementing IDashboardStorageService.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Action to configure dashboard options.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddBlazorDashboardWithCustomStorage<TStorageService>(
        this IServiceCollection services,
        Action<DashboardOptions> configure)
        where TStorageService : class, IDashboardStorageService
    {
        var options = new DashboardOptions();
        configure(options);
        services.AddSingleton(options);

        services.AddScoped<IThemeService, ThemeService>();
        services.AddScoped(sp => (ThemeService)sp.GetRequiredService<IThemeService>());
        services.AddScoped<IDashboardStorageService, TStorageService>();
        services.AddScoped<ChartService>();

        return services;
    }
}
