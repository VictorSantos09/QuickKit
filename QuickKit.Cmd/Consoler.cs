using QuickKit.Cmd.Enums;
using QuickKit.Cmd.Shared;

namespace QuickKit.Cmd;

/// <summary>
/// Provides utility methods for reading and writing to the console.
/// </summary>
public class Consoler
{
    #region Write
    /// <summary>
    /// Writes the specified message to the console.
    /// </summary>
    /// <param name="message">The message to write.</param>
    public static void Write(string message) => Writer.Write(message);

    /// <summary>
    /// Writes the specified message to the console with the specified alert type.
    /// </summary>
    /// <param name="message">The message to write.</param>
    /// <param name="type">The alert type.</param>
    public static void Write(string message, AlertType type) => Writer.Write(message, type);

    /// <summary>
    /// Writes the specified message followed by a new line to the console.
    /// </summary>
    /// <param name="message">The message to write.</param>
    public static void WriteLine(string message) => Writer.WriteLine(message);

    /// <summary>
    /// Writes the specified message followed by a new line to the console with the specified alert type.
    /// </summary>
    /// <param name="message">The message to write.</param>
    /// <param name="type">The alert type.</param>
    public static void WriteLine(string message, AlertType type) => Writer.WriteLine(message, type);
    #endregion

    #region Read
    /// <summary>
    /// Reads an integer value from the console.
    /// </summary>
    /// <returns>The integer value read from the console.</returns>
    public static int Read() => Reader.Read();

    /// <summary>
    /// Reads a line of text from the console.
    /// </summary>
    /// <returns>The line of text read from the console.</returns>
    public static string? ReadLine() => Reader.ReadLine();

    /// <summary>
    /// Reads a line of text from the console with the specified alert message and alert type if the input is null.
    /// </summary>
    /// <param name="notNullAlertMessage">The alert message to display if the input is null.</param>
    /// <param name="alertType">The alert type.</param>
    /// <returns>The line of text read from the console.</returns>
    public static string ReadLine(string notNullAlertMessage, AlertType alertType = AlertType.Warning)
    {
        return Reader.ReadLine(notNullAlertMessage, alertType);
    }

    /// <summary>
    /// Reads a key from the console.
    /// </summary>
    /// <returns>The key read from the console.</returns>
    public static ConsoleKey ReadKey() => Reader.ReadKey();

    /// <summary>
    /// Reads a key from the console and returns the key information.
    /// </summary>
    /// <returns>The key information read from the console.</returns>
    public static ConsoleKeyInfo ReadKeyInfo() => Reader.ReadKeyInfo();
    #endregion

    #region ReadAs
    /// <summary>
    /// Reads a value of the specified type from the console with the specified alert message and alert type if the input is null or cannot be converted to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the input to.</typeparam>
    /// <param name="notNullAlertMessage">The alert message to display if the input is null.</param>
    /// <param name="convertFailedMessage">The alert message to display if the input cannot be converted to the specified type.</param>
    /// <param name="alertType">The alert type.</param>
    /// <returns>The value of the specified type read from the console.</returns>
    public static T ReadAs<T>(string notNullAlertMessage, string convertFailedMessage, AlertType alertType = AlertType.Warning) where T : struct
    {
        return Reader.ReadAs<T>(notNullAlertMessage, convertFailedMessage, alertType);
    }
    #endregion
}
