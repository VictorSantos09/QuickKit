using Microsoft.AspNetCore.Mvc;
using QuickKit.ResultTypes.ValueObjects;
using System.Net;

namespace QuickKit.AspNetCore.Controllers.Converters
{
    public static class ResultConverter
    {
        #region Build
        private static ObjectResult Build(this ResultBase result, HttpStatusCode statusCode)
        {
            return new ObjectResult(result)
            {
                StatusCode = (int)statusCode
            };
        }

        #endregion

        #region Convert
        public static IActionResult Convert(this ResultBase result, HttpStatusCode failure, HttpStatusCode success = HttpStatusCode.OK)
        {
            if (result.IsSuccess) return Build(result, success);
            return Build(result, failure);
        }

        public static IActionResult Convert(this ResultBase result, Func<ResultBase, IActionResult> func)
        {
            return func(result);
        }

        public static IActionResult Convert<TType>(this Result<TType> result, Func<Result<TType>, IActionResult> func)
        {
            return func(result);
        }
        #endregion
    }
}
