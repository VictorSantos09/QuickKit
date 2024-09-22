using Radzen;

namespace QuickKit.Blazor.Services.Dialog;
public interface IDialogService
{
    Task<bool?> Confirm(string message = "Confirm?", string title = "Confirm", ConfirmOptions? options = null);
}