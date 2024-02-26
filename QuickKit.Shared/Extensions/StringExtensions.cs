namespace QuickKit.Shared.Extensions;

public static class StringExtensions
{
    #region Comparisons (IsEmpty...)
    /// <summary>
    /// Determines whether the specified string is empty, null, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>true if the string is empty, null, or consists only of white-space characters; otherwise, false.</returns>
    public static bool IsEmpty(this string? value)
    {
        return string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Determines whether the length of the specified string is higher than the specified length.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="length">The length to compare against.</param>
    /// <returns>true if the length of the string is higher than the specified length; otherwise, false.</returns>
    public static bool IsHigherThan(this string? value, int length)
    {
        return value?.Length > length;
    }

    /// <summary>
    /// Determines whether the length of the specified string is higher than or equal to the specified length.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="length">The length to compare against.</param>
    /// <returns>true if the length of the string is higher than or equal to the specified length; otherwise, false.</returns>
    public static bool IsHigherOrEqualThan(this string? value, int length)
    {
        return value?.Length >= length;
    }

    /// <summary>
    /// Determines whether the length of the specified string is lower than the specified length.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="length">The length to compare against.</param>
    /// <returns>true if the length of the string is lower than the specified length; otherwise, false.</returns>
    public static bool IsLowerThan(this string? value, int length)
    {
        return value?.Length < length;
    }

    /// <summary>
    /// Determines whether the length of the specified string is lower than or equal to the specified length.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="length">The length to compare against.</param>
    /// <returns>true if the length of the string is lower than or equal to the specified length; otherwise, false.</returns>
    public static bool IsLowerOrEqualThan(this string? value, int length)
    {
        return value?.Length <= length;
    }
    #endregion

    #region To (ToInt...)
    /// <summary>
    /// Converts the specified string to the specified type.
    /// </summary>
    /// <typeparam name="TType">The type to convert the string to.</typeparam>
    /// <param name="value">The string to convert.</param>
    /// <returns>The converted value of the specified type.</returns>
    public static TType To<TType>(this string value) where TType : struct
    {
        return (TType)Convert.ChangeType(value, typeof(TType));
    }

    /// <summary>
    /// Converts the specified string to an integer.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The converted integer value.</returns>
    public static int ToInt(this string value)
    {
        return int.Parse(value);
    }

    /// <summary>
    /// Converts the specified string to a double.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The converted double value.</returns>
    public static double ToDouble(this string value)
    {
        return double.Parse(value);
    }

    /// <summary>
    /// Converts the specified string to a decimal.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The converted decimal value.</returns>
    public static decimal ToDecimal(this string value)
    {
        return decimal.Parse(value);
    }

    /// <summary>
    /// Converts the specified string to a boolean.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The converted boolean value.</returns>
    public static bool ToBool(this string value)
    {
        return bool.Parse(value);
    }

    /// <summary>
    /// Converts the specified string to a DateTime.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The converted DateTime value.</returns>
    public static DateTime ToDateTime(this string value)
    {
        return DateTime.Parse(value);
    }

    /// <summary>
    /// Converts the specified string to a DateOnly.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The converted DateOnly value.</returns>
    public static DateOnly ToDateOnly(this string value)
    {
        return DateOnly.Parse(value);
    }
    #endregion
}
