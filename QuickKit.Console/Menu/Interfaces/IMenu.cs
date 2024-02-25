using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd.Menu.Interfaces;
public interface IMenu
{
    public abstract void Show();
    public abstract void ShowOptions();
    public abstract void ShowInvalidOptionMessage(string message, AlertType alertType = AlertType.Warning);
    public abstract int SelectOption();
    public abstract void GoToOption(int option);
}
