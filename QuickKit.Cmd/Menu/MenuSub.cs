using QuickKit.Cmd.Enums;
using QuickKit.Cmd.Menu.Interfaces;
using QuickKit.Cmd.Shared;

namespace QuickKit.Cmd.Menu;
public abstract class MenuSub : IMenuSub
{
    protected abstract string NotNullAlertMessage { get; set; }

    public virtual void Back()
    {
        return;
    }

    #region Option
    public abstract void GoToOption(int option);

    public virtual int SelectOption()
    {
        return int.Parse(Consoler.ReadLine(NotNullAlertMessage, AlertType.Warning));
    }
    #endregion

    #region Show
    public abstract void Show();

    public abstract void ShowOptions();

    public abstract void ShowPreviousOption();

    public virtual void ShowInvalidOptionMessage(string message, AlertType alertType = AlertType.Warning)
    {
        Alerter.ShowAlert(message, alertType);
    }
    #endregion
}
