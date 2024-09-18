using Microsoft.AspNetCore.Components;
using Radzen;

namespace QuickKit.Blazor.Services.Tip;

public class TipService(TooltipService tooltipService) : ITipService
{
    public void ShowTooltip(ElementReference elementReference, string message, TooltipOptions? options = null) => tooltipService.Open(elementReference, message, options);
}
