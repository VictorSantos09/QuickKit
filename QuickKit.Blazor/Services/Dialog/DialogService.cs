using Radzen;

namespace QuickKit.Blazor.Services.Dialog;
public class DialogService(Radzen.DialogService dialogService) : IDialogService
{
    public async Task<bool?> Confirm(string message = "Confirm?", string title = "Confirm", ConfirmOptions? options = null)
    {
        return await dialogService.Confirm(message, title, options);
    }

}
