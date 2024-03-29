using Microsoft.IdentityModel.Tokens;
using QuickKit.Security.Jwt.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace QuickKit.Security.Jwt;

/// <summary>
/// Represents a JWT token generator.
/// </summary>
internal class JwtTokenGenerator : IJwtTokenGenerator
{
    /// <summary>
    /// Generates a JWT token based on the provided token request.
    /// </summary>
    /// <param name="request">The token request containing the necessary information.</param>
    /// <returns>The generated JWT token.</returns>
    public string Generate(JwtTokenRequest request)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(request.TokenKey));
        var signingCredentials = new SigningCredentials(key, request.Algorithm);

        var token = new JwtSecurityToken(
            request.Issuer,
            request.Audience,
            request.Claims,
            request.NotBefore,
            request.Expires,
            signingCredentials);

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}
