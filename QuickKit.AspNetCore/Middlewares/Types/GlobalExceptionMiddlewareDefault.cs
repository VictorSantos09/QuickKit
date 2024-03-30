using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace QuickKit.AspNetCore.Middlewares.Types;

/// <summary>
/// Middleware for handling global exceptions in ASP.NET Core applications.
/// </summary>
public class GlobalExceptionMiddlewareDefault
{
    private readonly RequestDelegate _next;
    private readonly string _defaultMessage;
    private readonly bool _showStaceTrace;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptionMiddlewareDefault"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="defaultMessage">The default error message to be returned.</param>
    /// <param name="showStackStrace">A flag indicating whether to include the stack trace in the error response.</param>
    public GlobalExceptionMiddlewareDefault(RequestDelegate next,
                                            string defaultMessage = "An error has occurred while processing your request",
                                            bool showStackStrace = true)
    {
        _next = next;
        _defaultMessage = defaultMessage;
        _showStaceTrace = showStackStrace;
    }

    /// <summary>
    /// Builds the error response object based on the provided exception.
    /// </summary>
    /// <param name="ex">The exception.</param>
    /// <returns>The error response object.</returns>
    private object BuildResponse(Exception ex)
    {
        if (_showStaceTrace)
        {
            return new
            {
                error = new
                {
                    Message = _defaultMessage,
                    Details = ex.Message,
                    ex.StackTrace,
                    ex.Data,
                    ex.HelpLink,
                    ex.HResult,
                }
            };
        }

        return new
        {
            error = new
            {
                Message = _defaultMessage,
                Details = ex.Message,
                ex.Data,
                ex.HelpLink,
                ex.HResult,
            }
        };
    }

    /// <summary>
    /// Prepares the HTTP context response with the specified status code and content type.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="statusCode">The status code.</param>
    private static void PrepareContextResponse(HttpContext context, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
    }

    /// <summary>
    /// Invokes the middleware.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode)
    {
        PrepareContextResponse(context, statusCode);
        var response = BuildResponse(ex);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}
