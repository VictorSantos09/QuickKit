using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd.Shared;

/// <summary>
/// Provides methods for displaying alerts with different levels and colors.
/// </summary>
public class Alerter
{
    /// <summary>
    /// Sets the default foreground color for the console.
    /// </summary>
    private static void SetDefaultForegroundColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Sets the foreground color for the console.
    /// </summary>
    /// <param name="color">The color to set.</param>
    private static void SetForegroundColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    #region Alerters Levels

    /// <summary>
    /// Displays an error message with red foreground color.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    public static void Error(string message)
    {
        SetForegroundColor(ConsoleColor.Red);
        Console.WriteLine(message);
        SetDefaultForegroundColor();
    }

    /// <summary>
    /// Displays a success message with green foreground color.
    /// </summary>
    /// <param name="message">The success message to display.</param>
    public static void Success(string message)
    {
        SetForegroundColor(ConsoleColor.Green);
        Console.WriteLine(message);
        SetDefaultForegroundColor();
    }

    /// <summary>
    /// Displays a warning message with yellow foreground color.
    /// </summary>
    /// <param name="message">The warning message to display.</param>
    public static void Warning(string message)
    {
        SetForegroundColor(ConsoleColor.Yellow);
        Console.WriteLine(message);
        SetDefaultForegroundColor();
    }

    #endregion

    #region Alerts

    /// <summary>
    /// Displays an alert message with the specified text and type.
    /// </summary>
    /// <param name="text">The alert message to display.</param>
    /// <param name="type">The type of the alert.</param>
    public static void ShowAlert(string text, AlertType type)
    {
        switch (type)
        {
            case AlertType.None:
                break;
            case AlertType.Warning:
                Warning(text);
                break;
            case AlertType.Error:
                Error(text);
                break;
            case AlertType.Success:
                Success(text);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Displays an alert message with the specified message and foreground color.
    /// </summary>
    /// <param name="message">The alert message to display.</param>
    /// <param name="color">The foreground color of the alert.</param>
    public static void Alert(string message, ConsoleColor color)
    {
        SetForegroundColor(color);
        Console.WriteLine(message);
        SetDefaultForegroundColor();
    }

    #endregion
}
