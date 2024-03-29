using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd.Shared;

internal class Writer
{
    #region Write
    public static void Write(string text)
    {
        Console.Write(text);
    }

    public static void Write(string text, AlertType type)
    {
        Alerter.ShowAlert(text, type);
    }

    public static void WriteLine(string text)
    {
        Console.WriteLine(text);
    }

    public static void WriteLine(string text, AlertType type)
    {
        Alerter.ShowAlert(text, type);
    }
    #endregion
}
