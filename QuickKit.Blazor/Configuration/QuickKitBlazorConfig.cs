using Microsoft.Extensions.DependencyInjection;
using QuickKit.Blazor.Services.Navigation;
using QuickKit.Blazor.Services.Notification;
using QuickKit.Blazor.Services.Tip;

namespace QuickKit.Blazor.Configuration;

public static class QuickKitBlazorConfig
{
    public static IServiceCollection AddBlazorSupport(this IServiceCollection services)
    {
        services.AddScoped<ITipService, TipService>();
        services.AddScoped<INotifierService, NotifierService>();
        services.AddScoped<INavigationService, NavigationService>();

        return services;
    }
}
