using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using QuickKit.AspNetCore.Swagger.Configuration.Requests;

namespace QuickKit.AspNetCore.Swagger.Middlewares;

public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly SwaggerBasicAuthRequest _request;

    public SwaggerBasicAuthMiddleware(RequestDelegate next, SwaggerBasicAuthRequest request)
    {
        _next = next;
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments(_request.Path))
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var header = AuthenticationHeaderValue.Parse(authHeader);
                var inBytes = Convert.FromBase64String(header.Parameter);

                var credentials = Encoding.UTF8.GetString(inBytes).Split(':');

                var username = credentials[0];
                var password = credentials[1]; 

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
