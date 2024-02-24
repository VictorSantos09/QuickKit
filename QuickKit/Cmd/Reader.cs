using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd
{
    public class Reader
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

                if (input is null) Alerter.ShowAlert(notNullAlertMessage, alertType);
            } while (input is null);

            return input;
        }

        #endregion
    }
}
