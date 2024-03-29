using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace QuickKit.AspNetCore.Swagger.Configuration;

public static class SwaggerDocumentationConfiguration
{
    public static IServiceCollection AddSwaggerDocsFromXmlComments(this IServiceCollection services, Assembly assembly)
    {
        services.AddSwaggerGen(x =>
        {
            x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{assembly.GetName().Name}.xml"));
        });

        return services;
    }
}
