using Radzen;

namespace QuickKit.Blazor.Services.Navigation;
public interface INavigationService
{
    void Export(string table, string type, Query? query = null);
}