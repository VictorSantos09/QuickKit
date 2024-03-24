using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace QuickKit.ResultTypes.Converters
{
    public static class ResultConverter
    {
        #region Build
        private static ObjectResult Build(this FinalBase result, HttpStatusCode statusCode)
        {
            return new ObjectResult(result)
            {
                StatusCode = (int)statusCode
            };
        }

        #endregion

        #region Convert
        public static IActionResult Convert(this FinalBase result, HttpStatusCode failure, HttpStatusCode success = HttpStatusCode.OK)
        {
            if (result.IsSuccess) return result.Build(success);
            return result.Build(failure);
        }

        public static IActionResult Convert(this FinalBase result, Func<FinalBase, IActionResult> func)
        {
            return func(result);
        }

        public static IActionResult Convert<TType>(this Final<TType> result, Func<Final<TType>, IActionResult> func)
        {
            return func(result);
        }
        #endregion
    }
}
