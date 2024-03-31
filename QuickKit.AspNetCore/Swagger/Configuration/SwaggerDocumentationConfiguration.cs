using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace QuickKit.AspNetCore.Swagger.Configuration;

/// <summary>
/// Provides configuration methods for Swagger documentation.
/// </summary>
public static class SwaggerDocumentationConfiguration
{
    /// <summary>
    /// Adds Swagger documentation from XML comments to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the Swagger documentation to.</param>
    /// <param name="assembly">The assembly containing the XML comments file.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddSwaggerDocsFromXmlComments(this IServiceCollection services, Assembly assembly)
    {
        _ = services.AddSwaggerGen(x =>
        {
            x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{assembly.GetName().Name}.xml"));
        });

        return services;
    }
}
