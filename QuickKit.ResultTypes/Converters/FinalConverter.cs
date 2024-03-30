using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace QuickKit.ResultTypes.Converters;

/// <summary>
/// Provides extension methods for converting <see cref="Final"/> objects to <see cref="IActionResult"/>.
/// </summary>
public static class FinalConverter
{
    #region Build

    /// <summary>
    /// Builds an <see cref="ObjectResult"/> with the specified <paramref name="statusCode"/>.
    /// </summary>
    /// <param name="final">The <see cref="Final"/> object.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <returns>An <see cref="ObjectResult"/> with the specified <paramref name="statusCode"/>.</returns>
    private static ObjectResult Build(this Final final, HttpStatusCode statusCode)
    {
        return new ObjectResult(final)
        {
            StatusCode = (int)statusCode
        };
    }

    #endregion

    #region Convert

    /// <summary>
    /// Converts the <paramref name="final"/> object to an <see cref="IActionResult"/> based on the success or failure status.
    /// </summary>
    /// <param name="final">The <see cref="Final"/> object.</param>
    /// <param name="failure">The HTTP status code for failure.</param>
    /// <param name="success">The HTTP status code for success. Default is <see cref="HttpStatusCode.OK"/>.</param>
    /// <returns>An <see cref="IActionResult"/> based on the success or failure status of the <paramref name="final"/> object.</returns>
    public static IActionResult Convert(this Final final, HttpStatusCode failure, HttpStatusCode success = HttpStatusCode.OK)
    {
        return final.IsSuccess ? final.Build(success) : (IActionResult)final.Build(failure);
    }

    /// <summary>
    /// Converts the <paramref name="final"/> object to an <see cref="ActionResult{TType}"/> based on the success or failure status.
    /// </summary>
    /// <typeparam name="TType">The type of the <see cref="Final{TType}"/> object.</typeparam>
    /// <param name="final">The <see cref="Final{TType}"/> object.</param>
    /// <param name="failure">The HTTP status code for failure.</param>
    /// <param name="success">The HTTP status code for success. Default is <see cref="HttpStatusCode.OK"/>.</param>
    /// <returns>An <see cref="ActionResult{TType}"/> based on the success or failure status of the <paramref name="final"/> object.</returns>
    public static ActionResult<TType> Convert<TType>(this Final<TType> final, HttpStatusCode failure, HttpStatusCode success = HttpStatusCode.OK)
    {
        return final.IsSuccess ? final.Build(success) : (ActionResult<TType>)final.Build(failure);
    }

    /// <summary>
    /// Converts the <paramref name="final"/> object to an <see cref="IActionResult"/> using the specified <paramref name="func"/>.
    /// </summary>
    /// <param name="final">The <see cref="Final"/> object.</param>
    /// <param name="func">The function to convert the <paramref name="final"/> object to an <see cref="IActionResult"/>.</param>
    /// <returns>An <see cref="IActionResult"/> converted using the specified <paramref name="func"/>.</returns>
    public static IActionResult Convert(this Final final, Func<Final, IActionResult> func)
    {
        return func(final);
    }

    /// <summary>
    /// Converts the <paramref name="final"/> object to an <see cref="IActionResult"/> using the specified <paramref name="func"/>.
    /// </summary>
    /// <typeparam name="TType">The type of the <see cref="Final{TType}"/> object.</typeparam>
    /// <param name="final">The <see cref="Final{TType}"/> object.</param>
    /// <param name="func">The function to convert the <paramref name="final"/> object to an <see cref="IActionResult"/>.</param>
    /// <returns>An <see cref="IActionResult"/> converted using the specified <paramref name="func"/>.</returns>
    public static IActionResult Convert<TType>(this Final<TType> final, Func<Final<TType>, IActionResult> func)
    {
        return func(final);
    }

    #endregion
}
