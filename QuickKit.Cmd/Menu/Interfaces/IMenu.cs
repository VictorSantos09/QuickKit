using QuickKit.Cmd.Enums;

namespace QuickKit.Cmd.Menu.Interfaces
{
    /// <summary>
    /// Represents a menu interface.
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Displays the menu.
        /// </summary>
        public abstract void Show();

        /// <summary>
        /// Displays the menu options.
        /// </summary>
        public abstract void ShowOptions();

        /// <summary>
        /// Displays an invalid option message.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="alertType">The type of alert to display (default is Warning).</param>
        public abstract void ShowInvalidOptionMessage(string message, AlertType alertType = AlertType.Warning);

        /// <summary>
        /// Selects an option from the menu.
        /// </summary>
        /// <returns>The selected option.</returns>
        public abstract int SelectOption();

        /// <summary>
        /// Navigates to a specific option in the menu.
        /// </summary>
        /// <param name="option">The option to navigate to.</param>
        public abstract void GoToOption(int option);
    }
}
