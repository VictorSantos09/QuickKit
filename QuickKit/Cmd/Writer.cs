using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd
{
    public class Writer
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

        #endregion

        #region WriteLine

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
}
