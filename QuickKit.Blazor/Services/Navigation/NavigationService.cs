using Microsoft.AspNetCore.Components;
using Radzen;

namespace QuickKit.Blazor.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly NavigationManager _navigationManager;

    public NavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public void Export(string table, string type, Query? query = null)
    {
        _navigationManager.NavigateTo(query != null ? query.ToUrl($"api/file/export/{table}/{type}") : $"api/file/export/{table}/{type}", true);
    }
}
