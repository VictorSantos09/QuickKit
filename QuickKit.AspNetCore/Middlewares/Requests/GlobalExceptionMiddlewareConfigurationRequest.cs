using Microsoft.AspNetCore.Http;

namespace QuickKit.AspNetCore.Middlewares.Requests;

/// <summary>
/// Represents a configuration request for the GlobalExceptionMiddleware./>/>
/// </summary>
/// <typeparam name="TException">The type of exception to handle.</typeparam>
public readonly struct GlobalExceptionMiddlewareConfigurationRequest<TException> where TException : Exception
{
    /// <summary>
    /// Gets or sets the next request delegate in the pipeline.
    /// </summary>
    public RequestDelegate Next { get; init; }

    /// <summary>
    /// Gets or sets the exception to handle.
    /// </summary>
    public TException Exception { get; init; }

    /// <summary>
    /// Gets or sets the async exception handler function.
    /// </summary>
    public Func<HttpContext, TException, Task> ExceptionHandlerAsync { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptionMiddlewareConfigurationRequest{TException}"/>.
    /// </summary>
    /// <param name="next">The next request delegate in the pipeline.</param>
    /// <param name="exception">The exception to handle.</param>
    /// <param name="exceptionHandler">The async exception handler function.</param>
    public GlobalExceptionMiddlewareConfigurationRequest(RequestDelegate next,
                                          TException exception,
                                          Func<HttpContext, TException, Task> exceptionHandler)
    {
        Next = next;
        Exception = exception;
        ExceptionHandlerAsync = exceptionHandler;
    }
}
