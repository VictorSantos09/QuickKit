namespace QuickKit.Security.Jwt;

/// <summary>
/// Represents an interface for generating JWT tokens.
/// </summary>
public interface IJwtTokenGenerator
{
    /// <summary>
    /// Generates a JWT token based on the provided request.
    /// </summary>
    /// <param name="request">The request containing the necessary information for token generation.</param>
    /// <returns>The generated JWT token.</returns>
    public string Generate(JwtTokenRequest request);
}
