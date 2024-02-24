using QuickKit.Cmd;
using QuickKit.Cmd.Enums;
using QuickKit.Sample.Console.Menus;

namespace QuickKit.Sample.Console.Shared;

internal abstract class Menu : IMenu
{
    private const string _defaultInvalidMessage = "opção inválida, tente novamente";

    #region Options
    internal abstract void ShowOptions();
    internal abstract void GoToOption(int option);
    #endregion

    #region Shows
    internal virtual void ShowInvalidOptionMessage(string message = _defaultInvalidMessage, AlertType alertType = AlertType.Warning)
    {
        Alerter.ShowAlert(message, alertType);
    }

    internal virtual void ShowPreviousOption()
    {
        Writer.WriteLine("0 - Voltar");
    }

    public virtual void Show()
    {
        ShowPreviousOption();
        ShowOptions();
        var option = SelectOption();
        GoToOption(option);
    }

    #endregion

    internal virtual int SelectOption(string notNullAlertMessage = _defaultInvalidMessage)
    {
        Writer.Write("Opção: ");
        return int.Parse(Reader.ReadLine(notNullAlertMessage));
    }
    internal virtual void OnBack()
    {
        return;
    }
}
