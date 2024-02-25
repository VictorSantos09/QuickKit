using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd.Shared
{
    public class Alerter
    {
        private static void SetDefaultForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        #region Alerters Levels

        public static void Error(string message)
        {
            SetForegroundColor(ConsoleColor.Red);
            Console.WriteLine(message);
            SetDefaultForegroundColor();
        }

        public static void Success(string message)
        {
            SetForegroundColor(ConsoleColor.Green);
            Console.WriteLine(message);
            SetDefaultForegroundColor();
        }

        public static void Warning(string message)
        {
            SetForegroundColor(ConsoleColor.Yellow);
            Console.WriteLine(message);
            SetDefaultForegroundColor();
        }

        #endregion

        #region Alerts

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


        public static void Alert(string message, ConsoleColor color)
        {
            SetForegroundColor(color);
            Console.WriteLine(message);
            SetDefaultForegroundColor();
        }

        #endregion
    }
}
