using Microsoft.Extensions.DependencyInjection;
using QuickKit.Shared.Handlers;

namespace QuickKit.Configuration;

/// <summary>
/// Provides extension methods for configuring QuickKit.
/// </summary>
public static class KitConfiguration
{
    /// <summary>
    /// Adds QuickKit services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="connectionString">The connection string to use for the database.</param>
    /// <param name="config">An optional configuration function to customize the database connection handler.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddQuickKit(this IServiceCollection services, string connectionString, Func<IDatabaseConnectionHandler>? config = null)
    {
        if (config is null) services.AddSingleton<IDatabaseConnectionHandler>(new DatabaseConnectionHandlerMySQL(connectionString));
        
        else
        {
            var handler = config.Invoke();
            services.AddSingleton(handler);
        }

        return services;
    }
}
