using Microsoft.AspNetCore.Components;

namespace QuickKit.Shared.Extensions;

public static class ParameterViewExtensions
{
    public static bool ATTryGetValue<T>(this ParameterView parameterView, string key, out T? paramValue)
    {
        return parameterView.TryGetValue(key, out paramValue);
    }
}
