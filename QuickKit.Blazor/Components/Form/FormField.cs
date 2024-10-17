using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QuickKit.Blazor.Common.Interfaces.Components.Base;
using QuickKit.Blazor.Components.Grid;
using Radzen;
using System.Globalization;
using System.Linq.Expressions;

namespace QuickKit.Blazor.Components.Form;

public class FormField
{
    public string Text { get; set; }
    public Variant Variant { get; set; } = Variant.Flat;
    public bool AllowFloatingLabel { get; set; } = true;
    public bool Visible { get; set; } = true;
    public string Style { get; set; }
    public CultureInfo Culture { get; set; }
    public string Helper { get; set; }
    public EventCallback<ElementReference> OnMouseEnter { get; set; }
    public EventCallback<ElementReference> OnMouseLeave { get; set; }
    public  FormFieldOptions<IRadzenComponent> Options { get; set; }
    public string Value { get; set; }

    public class FormFieldOptions<T> where T : IRadzenComponent
{
    public RadzenFormInputType Type { get; set; }
    public T Model { get; set; }
}
}