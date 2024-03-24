using Microsoft.AspNetCore.Builder;
using QuickKit.AspNetCore.Swagger.Middlewares;
using QuickKit.AspNetCore.Swagger.Requests;

namespace QuickKit.AspNetCore.Swagger.Configuration
{
    public static class SwaggerBasicAuthConfiguration
    {
        public static IApplicationBuilder UseSwaggerAuthorizationMiddleware(this IApplicationBuilder builder, SwaggerBasicAuthRequest request)
        {
            return builder.UseMiddleware<SwaggerBasicAuthMiddleware>(request);
        }
    }
}
