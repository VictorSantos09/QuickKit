using Microsoft.AspNetCore.Http;
using QuickKit.AspNetCore.Middlewares.Requests;

namespace QuickKit.AspNetCore.Middlewares.Types;

/// <summary>
/// Represents a custom global exception middleware that handles a specific type of exception.
/// </summary>
/// <typeparam name="TException">The type of exception to handle.</typeparam>
public class GlobalExceptiomMiddlewareCustom<TException> where TException : Exception
{
    private readonly GlobalExceptionMiddlewareConfigurationRequest<TException> _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptiomMiddlewareCustom{TException}"/> class.
    /// </summary>
    /// <param name="config">The configuration for the middleware.</param>
    public GlobalExceptiomMiddlewareCustom(GlobalExceptionMiddlewareConfigurationRequest<TException> config)
    {
        _config = config;
    }

    /// <summary>
    /// Invokes the middleware asynchronously.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _config.Next(context);
        }
        catch (TException ex)
        {
            await _config.ExceptionHandlerAsync(context, ex);
        }
    }
}
