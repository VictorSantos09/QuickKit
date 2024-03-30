using QuickKit.Cmd.Enums;
using QuickKit.Shared.Extensions;

namespace QuickKit.Cmd.Shared;

internal class Reader
{
    #region ReadLine

    /// <summary>
    /// Reads a line of input from the console.
    /// </summary>
    /// <returns>The input read from the console.</returns>
    public static string? ReadLine()
    {
        return Console.ReadLine();
    }

    /// <summary>
    /// Reads a line of input from the console, displaying an alert message if the input is null or empty.
    /// </summary>
    /// <param name="notNullAlertMessage">The alert message to display if the input is null or empty.</param>
    /// <param name="alertType">The type of alert to display (default is Warning).</param>
    /// <returns>The input read from the console.</returns>
    public static string ReadLine(string notNullAlertMessage, AlertType alertType = AlertType.Warning)
    {
        string? input;
        do
        {
            input = Console.ReadLine();

            if (input.IsEmpty()) Alerter.ShowAlert(notNullAlertMessage, alertType);
        } while (input.IsEmpty());

        return input;
    }

    #endregion]

    #region Read
    /// <summary>
    /// Reads the next character from the console input.
    /// </summary>
    /// <returns>The next character read from the console input.</returns>
    public static int Read()
    {
        return Console.Read();
    }
    #endregion

    #region ReadKey
    /// <summary>
    /// Reads the next key pressed by the user from the console input.
    /// </summary>
    /// <returns>The ConsoleKey value that represents the key pressed by the user.</returns>
    public static ConsoleKey ReadKey()
    {
        return Console.ReadKey().Key;
    }

    /// <summary>
    /// Reads the next key pressed by the user from the console input, including the key's character representation and modifier keys.
    /// </summary>
    /// <returns>A ConsoleKeyInfo object that represents the key pressed by the user.</returns>
    public static ConsoleKeyInfo ReadKeyInfo()
    {
        return Console.ReadKey();
    }
    #endregion

    #region ReadAs
    /// <summary>
    /// Reads a line of input from the console and converts it to the specified type.
    /// Displays an alert message if the input is null or empty, or if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type to convert the input to.</typeparam>
    /// <param name="notNullAlertMessage">The alert message to display if the input is null or empty.</param>
    /// <param name="convertFailedMessage">The alert message to display if the conversion fails.</param>
    /// <param name="alertType">The type of alert to display (default is Warning).</param>
    /// <returns>The input converted to the specified type.</returns>
    public static T ReadAs<T>(string notNullAlertMessage,
                              string convertFailedMessage,
                              AlertType alertType = AlertType.Warning) where T : struct
    {
        string result = ReadLine(notNullAlertMessage, alertType);

        try
        {
            T output = (T)Convert.ChangeType(result, typeof(T));
            return output;
        }
        catch (InvalidCastException)
        {
            Consoler.WriteLine(convertFailedMessage, alertType);
            throw;
        }

        catch (FormatException)
        {
            Consoler.WriteLine(convertFailedMessage, alertType);
            throw;
        }
    }

    #endregion
}
