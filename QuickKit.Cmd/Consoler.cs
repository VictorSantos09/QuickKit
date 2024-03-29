using QuickKit.Cmd.Enums;
using QuickKit.Cmd.Shared;

namespace QuickKit.Cmd;
public class Consoler
{
    #region Write
    public static void Write(string message) => Writer.Write(message);
    public static void Write(string message, AlertType type) => Writer.Write(message, type);
    public static void WriteLine(string message) => Writer.WriteLine(message);
    public static void WriteLine(string message, AlertType type) => Writer.WriteLine(message, type);
    #endregion

    #region Read
    public static int Read() => Reader.Read();

    public static string? ReadLine() => Reader.ReadLine();

    public static string ReadLine(string notNullAlertMessage, AlertType alertType = AlertType.Warning)
    {
        return Reader.ReadLine(notNullAlertMessage, alertType);
    }

    public static ConsoleKey ReadKey() => Reader.ReadKey();

    public static ConsoleKeyInfo ReadKeyInfo() => Reader.ReadKeyInfo();
    #endregion

    #region ReadAs
    public static T ReadAs<T>(string notNullAlertMessage,
                              string convertFailedMessage,
                              AlertType alertType = AlertType.Warning) where T : struct
    {
        return Reader.ReadAs<T>(notNullAlertMessage, convertFailedMessage, alertType);
    }

    #endregion
}
