using QuickKit.Cmd.Enums;
using QuickKit.Cmd.Menu.Interfaces;
using QuickKit.Cmd.Shared;

namespace QuickKit.Cmd.Menu;

public abstract class MenuMain : IMenuMain
{
    public virtual void Exit()
    {
        Environment.Exit(0);
    }

    #region Option
    public abstract void GoToOption(int option);

    public abstract int SelectOption();
    #endregion

    #region Show
    public abstract void ShowOptions();

    public virtual void Show()
    {
        ShowOptions();
        int option = SelectOption();
        GoToOption(option);
    }

    public virtual void ShowInvalidOptionMessage(string message, AlertType alertType = AlertType.Warning)
    {
        Alerter.ShowAlert(message, alertType);
    }
    #endregion
}
