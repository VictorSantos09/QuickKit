using Microsoft.AspNetCore.Http;

namespace QuickKit.AspNetCore.Swagger.Configuration.Requests;

/// <summary>
/// Represents a basic authentication request for Swagger.
/// </summary>
public record SwaggerBasicAuthRequest
{
    /// <summary>
    /// Gets the path string.
    /// </summary>
    public readonly PathString Path;
    /// <summary>
    /// Gets the username for basic authentication.
    /// </summary>
    public readonly string Username;
    /// <summary>
    /// Gets or sets the password for basic authentication.
    /// </summary>
    public readonly string Password;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwaggerBasicAuthRequest"/> class.
    /// </summary>
    /// <param name="path">The path to apply the basic authentication.</param>
    /// <param name="username">The username for basic authentication.</param>
    /// <param name="password">The password for basic authentication.</param>
    public SwaggerBasicAuthRequest(PathString path, string username, string password)
    {
        Path = path;
        Username = username;
        Password = password;
    }
    private SwaggerBasicAuthRequest()
    {

    }
}
