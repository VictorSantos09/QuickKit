using Microsoft.Extensions.DependencyInjection;
using QuickKit.Security.Configuration.Jwt;
using QuickKit.Security.Jwt;

namespace QuickKit.Security.Configuration;

/// <summary>
/// Provides methods to configure security settings.
/// </summary>
public static class SecurityConfiguration
{
    /// <summary>
    /// Adds JWT Bearer authentication to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the authentication services to.</param>
    /// <param name="key">The byte array representing the secret key used for token generation and validation.</param>
    /// <param name="issuer">The issuer of the JWT tokens.</param>
    /// <param name="audience">The audience of the JWT tokens.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddJwtBearerKit(this IServiceCollection services, byte[] key, string issuer, string audience)
    {
        _ = services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        JwtBearerConfiguration.Configure(services, key, issuer, audience);
        return services;
    }
}
