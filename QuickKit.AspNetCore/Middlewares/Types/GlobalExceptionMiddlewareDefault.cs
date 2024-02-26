﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using QuickKit.Shared.Exceptions;
using System.ComponentModel.DataAnnotations;
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
        catch (EntityNotFoundException ex)
        {
            await HandleEntityNotFoundExceptionAsync(context, ex);
        }
        catch (NotFoundException ex)
        {
            await HandleNotFoundExceptionAsync(context, ex);
        }
        catch (ValidationFailureException ex)
        {
            await HandleValidationFailureExceptionAsync(context, ex);
        }
        catch (SnapshotNullException ex)
        {
            await SnapshotNullExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    #region Exceptions Handlers
    /// <summary>
    /// Handles the <see cref="EntityNotFoundException"/> exception.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The exception.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private Task HandleEntityNotFoundExceptionAsync(HttpContext context, EntityNotFoundException ex)
    {
        PrepareContextResponse(context, HttpStatusCode.NotFound);
        var response = BuildResponse(ex);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }

    /// <summary>
    /// Handles the generic <see cref="Exception"/> exception.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The exception.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        PrepareContextResponse(context, HttpStatusCode.InternalServerError);
        var response = BuildResponse(ex);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }

    /// <summary>
    /// Handles the <see cref="NotFoundException"/> exception.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The exception.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException ex)
    {
        PrepareContextResponse(context, HttpStatusCode.NotFound);
        var response = BuildResponse(ex);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }

    /// <summary>
    /// Handles the <see cref="ValidationFailureException"/> exception.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The exception.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private Task HandleValidationFailureExceptionAsync(HttpContext context, ValidationFailureException ex)
    {
        PrepareContextResponse(context, HttpStatusCode.BadRequest);
        var response = BuildResponse(ex);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }

    /// <summary>
    /// Handles the <see cref="SnapshotNullException"/> exception.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The exception.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private Task SnapshotNullExceptionAsync(HttpContext context, SnapshotNullException ex)
    {
        PrepareContextResponse(context, HttpStatusCode.InternalServerError);
        var response = BuildResponse(ex);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
    #endregion
}
