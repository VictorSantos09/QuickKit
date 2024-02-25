using QuickKit.Cmd.Enums;
using QuickKit.Shared.Extensions;

namespace QuickKit.Cmd.Shared
{
    internal class Reader
    {
        #region ReadLine

        public static string? ReadLine()
        {
            return Console.ReadLine();
        }

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
        public static int Read()
        {
            return Console.Read();
        }
        #endregion

        #region ReadKey
        public static ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }

        public static ConsoleKeyInfo ReadKeyInfo()
        {
            return Console.ReadKey();
        }
        #endregion

        #region ReadAs
        public static T ReadAs<T>(string notNullAlertMessage,
                                  string convertFailedMessage,
                                  AlertType alertType = AlertType.Warning) where T : struct
        {
            var result = ReadLine(notNullAlertMessage, alertType);

            try
            {
                var output = (T)Convert.ChangeType(result, typeof(T));
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
}
