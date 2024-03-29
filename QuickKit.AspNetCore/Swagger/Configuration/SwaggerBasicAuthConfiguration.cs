using Microsoft.AspNetCore.Builder;
using QuickKit.AspNetCore.Swagger.Configuration.Requests;
using QuickKit.AspNetCore.Swagger.Middlewares;

namespace QuickKit.AspNetCore.Swagger.Configuration;

public static class SwaggerBasicAuthConfiguration
{
    public static IApplicationBuilder UseSwaggerAuthorizationMiddleware(this IApplicationBuilder builder, SwaggerBasicAuthRequest request)
    {
        return builder.UseMiddleware<SwaggerBasicAuthMiddleware>(request);
    }
}
