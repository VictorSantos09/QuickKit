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
    public static bool IsNull(this object obj)
    {
        return obj is null;
    }
}
