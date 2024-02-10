using Microsoft.Extensions.DependencyInjection;
using QuickKit.Shared.Handlers;

namespace QuickKit.Configuration;
public static class QuickKitConfiguration
{
    public static IServiceCollection AddQuickKit(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton(new DatabaseConnectionHandler(connectionString));
        return services;
    }
}
