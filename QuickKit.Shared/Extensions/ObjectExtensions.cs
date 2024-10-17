
namespace QuickKit.Shared.Extensions;

/// <summary>
/// Provides extension methods for working with objects.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Determines whether the specified object is null.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <returns>true if the object is null; otherwise, false.</returns>
    public static bool IsNull(this object? obj)
    {
        return obj is null;
    }

    #region Get Property Value

    public static T GetValueFromProperty<T>(this object obj, string propertyName)
    {
        var objValue = obj?.GetType().GetProperty(propertyName)?.GetValue(obj, null);
        return objValue is null ? default(T) : (T)objValue;
    }

    public static string? GetPropertyValueString(this object obj, string propertyName)
    {
        var objValue = GetValueFromProperty<string>(obj, propertyName);
        return objValue is null ? null : objValue.ToString();
    }

    public static T? GetPropertyValue<T>(this object obj, string propertyName)
    {
        var objValue = GetValueFromProperty<T>(obj, propertyName);
        return objValue is null ? default(T) : (T)objValue;
    }

    #region Get Value Numeric
    public static int GetPropertyValueInt(this object obj, string propertyName)
    {
        var objValue = GetValueFromProperty<int>(obj, propertyName);
        return objValue == 0 ? 0 : int.Parse(objValue.ToString());
    }

    public static long GetPropertyValueLong(this object obj, string propertyName)
    {
        var objValue = GetValueFromProperty<long>(obj, propertyName);
        return objValue == 0 ? 0 : long.Parse(objValue.ToString());
    }

    public static float GetPropertyValueFloat(this object obj, string propertyName)
    {
        var objValue = GetValueFromProperty<float>(obj, propertyName);
        return objValue == 0 ? 0 : float.Parse(objValue.ToString());
    }

    public static double GetPropertyValueDouble(this object obj, string propertyName)
    {
        var objValue = GetValueFromProperty<double>(obj, propertyName);
        return objValue == 0 ? 0 : double.Parse(objValue.ToString());
    }
    #endregion

    public static bool GetPropertyValueBool(this object obj, string propertyName)
    {
        var objValue = GetValueFromProperty<bool>(obj, propertyName);
        return bool.Parse(objValue.ToString());
    }

    #endregion


    #region Set Property Value

    public static T? SetPropertyValue<T>(this object obj, string propertyName, T value)
    {
        var propertyInfo = obj?.GetType().GetProperty(propertyName);
        if (propertyInfo != null && propertyInfo.CanWrite)
        {
            propertyInfo.SetValue(obj, value);
            return value;
        }

        return default(T);
    }

    public static T? SetPropertyValue<T>(this object obj, string propertyName, object value)
    {
        var propertyInfo = obj?.GetType().GetProperty(propertyName);
        if (propertyInfo != null && propertyInfo.CanWrite)
        {
            propertyInfo.SetValue(obj, value);
            return (T)value;
        }

        return default(T);
    }

    #endregion
}
