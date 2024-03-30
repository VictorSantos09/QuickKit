using Microsoft.AspNetCore.Http;

namespace QuickKit.AspNetCore.Swagger.Configuration.Requests;

public record SwaggerBasicAuthRequest
{
    public readonly PathString Path;
    public readonly string Username;
    public readonly string Password;

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
