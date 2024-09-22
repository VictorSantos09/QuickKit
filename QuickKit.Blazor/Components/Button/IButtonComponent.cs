using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Globalization;

namespace QuickKit.Blazor.Components.Button;
public interface IButtonComponent<T>
{
    ButtonStyle ButtonStyle { get; set; }
    Variant Variant { get; set; }
    Shade Shade { get; set; }
    string Icon { get; set; }
    string BusyText { get; set; }
    ButtonType ButtonType { get; set; }
    bool Disabled { get; set; }
    string IconColor { get; set; }
    string Image { get; set; }
    bool IsBusy { get; set; }
    string ImageAlternateText { get; set; }
    EventCallback<ElementReference> MouseEnter { get; set; }
    EventCallback<ElementReference> MouseLeave { get; set; }
    EventCallback<T> OnClick { get; set; }
    ButtonSize Size { get; set; }
    string Style { get; set; }
    string Text { get; set; }
    bool Visible { get; set; }
    CultureInfo Culture { get; set; }
}
