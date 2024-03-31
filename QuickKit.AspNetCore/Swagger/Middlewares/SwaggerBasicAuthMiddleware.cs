using Microsoft.AspNetCore.Http;
using QuickKit.AspNetCore.Swagger.Configuration.Requests;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace QuickKit.AspNetCore.Swagger.Middlewares;

/// <summary>
/// Middleware for handling basic authentication for Swagger.
/// </summary>
public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly SwaggerBasicAuthRequest _request;

    /// <summary>
    /// Middleware for handling Swagger basic authentication.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="request">The Swagger basic authentication request.</param>
    public SwaggerBasicAuthMiddleware(RequestDelegate next, SwaggerBasicAuthRequest request)
    {
        _next = next;
        _request = request;
    }

    /// <summary>
    /// Represents an asynchronous operation that can return a value.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments(_request.Path))
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                AuthenticationHeaderValue header = AuthenticationHeaderValue.Parse(authHeader);
                byte[] inBytes = Convert.FromBase64String(header.Parameter);

                string[] credentials = Encoding.UTF8.GetString(inBytes).Split(':');

                string username = credentials[0];
                string password = credentials[1];

                if (username.Equals(_request.Username)
                  && password.Equals(_request.Password))
                {
                    await _next.Invoke(context).ConfigureAwait(false);
                    return;
                }
            }
            context.Response.Headers["WWW-Authenticate"] = "Basic";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await _next.Invoke(context).ConfigureAwait(false);
        }
    }
}
