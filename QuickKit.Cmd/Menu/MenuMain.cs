using QuickKit.Cmd.Enums;
using QuickKit.Cmd.Menu.Interfaces;
using QuickKit.Cmd.Shared;

namespace QuickKit.Cmd.Menu;
/// <summary>
/// Represents the main menu of the application.
/// </summary>
public abstract class MenuMain : IMenuMain
{
    /// <inheritdoc/>
    public virtual void Exit()
    {
        Environment.Exit(0);
    }
    /// <inheritdoc/>

    #region Option
    public abstract void GoToOption(int option);
    /// <inheritdoc/>

    public abstract int SelectOption();
    /// <inheritdoc/>
    #endregion

    #region Show
    public abstract void ShowOptions();
    /// <inheritdoc/>

    public virtual void Show()
    {
        ShowOptions();
        int option = SelectOption();
        GoToOption(option);
    }
    /// <inheritdoc/>
    public virtual void ShowInvalidOptionMessage(string message, AlertType alertType = AlertType.Warning)
    {
        Alerter.ShowAlert(message, alertType);
    }
    #endregion
}
