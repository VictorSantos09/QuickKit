namespace QuickKit.Cmd.Menu.Interfaces;

/// <summary>
/// Represents a sub-menu in a menu system.
/// </summary>
public interface IMenuSub : IMenu
{
    /// <summary>
    /// Shows the previous option in the sub-menu.
    /// </summary>
    void ShowPreviousOption();

    /// <summary>
    /// Goes back to the previous menu.
    /// </summary>
    void Back();
}