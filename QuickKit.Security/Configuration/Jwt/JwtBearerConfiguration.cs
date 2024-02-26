using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace QuickKit.Security.Configuration.Jwt
{
    /// <summary>
    /// Represents the configuration for JWT bearer authentication.
    /// </summary>
    public class JwtBearerConfiguration
    {
        /// <summary>
        /// Configures the authentication services for JWT bearer authentication.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        /// <param name="key">The byte array representing the secret key used for token validation.</param>
        /// <param name="issuer">The issuer of the JWT tokens.</param>
        /// <param name="audience">The audience of the JWT tokens.</param>
        private static void ConfigureAuthentication(IServiceCollection services, byte[] key, string issuer, string audience)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });
        }

        /// <summary>
        /// Configures the services for JWT bearer authentication.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        /// <param name="key">The byte array representing the secret key used for token validation.</param>
        /// <param name="issuer">The issuer of the JWT tokens.</param>
        /// <param name="audience">The audience of the JWT tokens.</param>
        public static void Configure(IServiceCollection services, byte[] key, string issuer, string audience)
        {
            ConfigureAuthentication(services, key, issuer, audience);
        }
    }
}
