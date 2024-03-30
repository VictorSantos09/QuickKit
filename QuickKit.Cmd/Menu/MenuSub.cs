using QuickKit.Cmd.Enums;
using QuickKit.Cmd.Menu.Interfaces;
using QuickKit.Cmd.Shared;

namespace QuickKit.Cmd.Menu;
/// <summary>
/// Represents an abstract base class for menu sub-classes.
/// </summary>
public abstract class MenuSub : IMenuSub
{
    /// <summary>
    /// Gets or sets the alert message displayed when the value is null.
    /// </summary>
    protected abstract string NotNullAlertMessage { get; set; }
/// <inheritdoc/>

    public virtual void Back()
    {
        return;
    }
/// <inheritdoc/>

    #region Option
    public abstract void GoToOption(int option);
/// <inheritdoc/>

    public virtual int SelectOption()
    {
        return int.Parse(Consoler.ReadLine(NotNullAlertMessage, AlertType.Warning));
    }
    /// <inheritdoc/>
    #endregion

    #region Show
    public abstract void Show();
/// <inheritdoc/>

    public abstract void ShowOptions();
/// <inheritdoc/>

    public abstract void ShowPreviousOption();
/// <inheritdoc/>

    public virtual void ShowInvalidOptionMessage(string message, AlertType alertType = AlertType.Warning)
    {
        Alerter.ShowAlert(message, alertType);
    }
    #endregion
}
