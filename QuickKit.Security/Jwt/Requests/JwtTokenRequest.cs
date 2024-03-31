using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace QuickKit.Security.Jwt.Requests;

/// <summary>
/// Represents a request for generating a JWT token.
/// </summary>
public readonly struct JwtTokenRequest
{
    /// <summary>
    /// Gets or sets the claims associated with the JWT token.
    /// </summary>
    public IEnumerable<Claim> Claims { get; init; }
    /// <summary>
    /// Gets or sets the expiration date and time of the JWT token.
    /// </summary>
    public DateTime Expires { get; init; }
    /// <summary>
    /// Gets or sets the token key.
    /// </summary>
    public string TokenKey { get; init; }
    /// <summary>
    /// Gets or sets the issuer of the JWT token.
    /// </summary>
    public string Issuer { get; init; }
    /// <summary>
    /// Gets or sets the audience for the JWT token.
    /// </summary>
    public string Audience { get; init; }
    /// <summary>
    /// Gets or sets the "Not Before" (nbf) claim value of the JWT token.
    /// This represents the time before which the token is not valid.
    /// </summary>
    public DateTime? NotBefore { get; init; }
    /// <summary>
    /// Gets or sets the algorithm used for generating the JWT token.
    /// The default value is <see cref="SecurityAlgorithms.HmacSha256"/>.
    /// </summary>
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
