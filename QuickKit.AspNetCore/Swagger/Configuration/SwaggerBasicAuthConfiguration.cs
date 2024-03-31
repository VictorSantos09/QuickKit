using Microsoft.AspNetCore.Builder;
using QuickKit.AspNetCore.Swagger.Configuration.Requests;
using QuickKit.AspNetCore.Swagger.Middlewares;

namespace QuickKit.AspNetCore.Swagger.Configuration;

/// <summary>
/// Provides configuration for Swagger basic authentication.
/// </summary>
public static class SwaggerBasicAuthConfiguration
{
    /// <summary>
    /// Adds the Swagger basic authentication middleware to the application pipeline.
    /// </summary>
    /// <param name="builder">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="request">The <see cref="SwaggerBasicAuthRequest"/> instance.</param>
    /// <returns>The updated <see cref="IApplicationBuilder"/> instance.</returns>
    public static IApplicationBuilder UseSwaggerAuthorizationMiddleware(this IApplicationBuilder builder, SwaggerBasicAuthRequest request)
    {
        return builder.UseMiddleware<SwaggerBasicAuthMiddleware>(request);
    }
}
