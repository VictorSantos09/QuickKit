using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace QuickKit.ResultTypes.Converters;

public static class FinalConverter
{
    #region Build
    private static ObjectResult Build(this FinalBase final, HttpStatusCode statusCode)
    {
        return new ObjectResult(final)
        {
            StatusCode = (int)statusCode
        };
    }

    #endregion

    #region Convert
    public static IActionResult Convert(this FinalBase final, HttpStatusCode failure, HttpStatusCode success = HttpStatusCode.OK)
    {
        if (final.IsSuccess) return final.Build(success);
        return final.Build(failure);
    }

    public static IActionResult Convert(this FinalBase final, Func<FinalBase, IActionResult> func)
    {
        return func(final);
    }

    public static IActionResult Convert<TType>(this Final<TType> final, Func<Final<TType>, IActionResult> func)
    {
        return func(final);
    }
    #endregion
}
