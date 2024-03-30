using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd.Shared;

internal class Writer
{
    #region Write
    /// <summary>
    /// Writes the specified text to the console.
    /// </summary>
    /// <param name="text">The text to write.</param>
    public static void Write(string text)
    {
        Console.Write(text);
    }

    /// <summary>
    /// Writes the specified text to the console and shows an alert of the specified type.
    /// </summary>
    /// <param name="text">The text to write.</param>
    /// <param name="type">The type of alert to show.</param>
    public static void Write(string text, AlertType type)
    {
        Alerter.ShowAlert(text, type);
    }

    /// <summary>
    /// Writes the specified text to the console followed by a new line.
    /// </summary>
    /// <param name="text">The text to write.</param>
    public static void WriteLine(string text)
    {
        Console.WriteLine(text);
    }

    /// <summary>
    /// Writes the specified text to the console followed by a new line and shows an alert of the specified type.
    /// </summary>
    /// <param name="text">The text to write.</param>
    /// <param name="type">The type of alert to show.</param>
    public static void WriteLine(string text, AlertType type)
    {
        Alerter.ShowAlert(text, type);
    }
    #endregion
}
