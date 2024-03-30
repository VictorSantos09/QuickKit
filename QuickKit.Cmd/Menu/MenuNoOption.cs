using QuickKit.Cmd.Menu.Interfaces;

namespace QuickKit.Cmd.Menu;

/// <summary>
/// Represents an abstract menu without any options.
/// </summary>
public abstract class MenuNoOption : IMenuNoOption
{
    /// <inheritdoc/>
    public abstract void Show();
}
