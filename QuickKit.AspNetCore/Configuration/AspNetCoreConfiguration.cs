using Microsoft.AspNetCore.Builder;
using QuickKit.AspNetCore.Middlewares.Requests;
using QuickKit.AspNetCore.Middlewares.Types;

namespace QuickKit.AspNetCore.Configuration;

/// <summary>
/// Provides extension methods for configuring ASP.NET Core middleware related to global exception handling.
/// </summary>
public static class AspNetCoreConfiguration
{
    /// <summary>
    /// Adds the default global exception middleware to the application pipeline.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="defaultMessage">The default error message to be displayed when an exception occurs.</param>
    /// <param name="showStackTrace">A flag indicating whether to include the stack trace in the error message.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
    public static IApplicationBuilder AddDefaultGlobalExceptionMiddleware(this IApplicationBuilder app,
                                                                          string defaultMessage = "An error has occurred while processing your request",
                                                                          bool showStackTrace = true)
    {
        _ = app.UseMiddleware<GlobalExceptionMiddlewareDefault>(defaultMessage, showStackTrace);
        return app;
    }

    /// <summary>
    /// Adds custom global exception middleware to the application pipeline.
    /// </summary>
    /// <typeparam name="TException">The type of exception to be handled by the middleware.</typeparam>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <param name="config">The configuration for the custom global exception middleware.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
    public static IApplicationBuilder AddCustomGlobalExceptionMiddleware<TException>(this IApplicationBuilder app,
                                                                                     GlobalExceptionMiddlewareConfigurationRequest<TException> config)
        where TException : Exception
    {
        _ = app.UseMiddleware<GlobalExceptiomMiddlewareCustom<TException>>(config);
        return app;
    }
}
