using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using System.Globalization;

namespace QuickKit.Blazor.Components.Button;
public class ButtonComponent<T> : IButtonComponent<T>
{
    public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.Info;
    public Variant Variant { get; set; } = Variant.Filled;
    public Shade Shade { get; set; } = Shade.Lighter;
    public string Icon { get; set; }
    public string BusyText { get; set; }
    public ButtonType ButtonType { get; set; } = ButtonType.Button;
    public bool Disabled { get; set; }
    public string IconColor { get; set; }
    public string Image { get; set; }
    public bool IsBusy { get; set; }
    public string ImageAlternateText { get; set; }
    public EventCallback<ElementReference> MouseEnter { get; set; }
    public EventCallback<ElementReference> MouseLeave { get; set; }
    public EventCallback<T> OnClick { get; set; }
    public ButtonSize Size { get; set; } = ButtonSize.Medium;
    public string Style { get; set; }
    public string Text { get; set; }
    public bool Visible { get; set; } = true;
    public CultureInfo Culture { get; set; }
}

