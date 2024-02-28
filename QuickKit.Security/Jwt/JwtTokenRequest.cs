using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace QuickKit.Security.Jwt;

/// <summary>
/// Represents a request for generating a JWT token.
/// </summary>
public readonly struct JwtTokenRequest
{
    public IEnumerable<Claim> Claims { get; init; }
    public DateTime Expires { get; init; }
    public string TokenKey { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public DateTime? NotBefore { get; init; }
    public string Algorithm { get; init; } = SecurityAlgorithms.HmacSha256;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtTokenRequest"/> struct.
    /// </summary>
    /// <param name="claims">The claims to include in the token.</param>
    /// <param name="expires">The expiration date and time of the token.</param>
    /// <param name="tokenKey">The key used to sign the token.</param>
    /// <param name="issuer">The issuer of the token.</param>
    /// <param name="audience">The audience of the token.</param>
    /// <param name="notBefore">The not-before date and time of the token.</param>
    /// <param name="algorithm">The algorithm used to sign the token.</param>
    public JwtTokenRequest(IEnumerable<Claim> claims,
                           DateTime expires,
                           string tokenKey,
                           string issuer,
                           string audience,
                           DateTime? notBefore = null,
                           string algorithm = SecurityAlgorithms.HmacSha256)
    {
        Claims = claims;
        Expires = expires;
        TokenKey = tokenKey;
        Issuer = issuer;
        Audience = audience;
        NotBefore = notBefore;
        Algorithm = algorithm;
    }

}
