using Microsoft.AspNetCore.Components;
using Radzen;

namespace QuickKit.Blazor.Services.Tip
{
    public interface ITipService
    {
        void ShowTooltip(ElementReference elementReference, string message, TooltipOptions? options = null);
    }
}