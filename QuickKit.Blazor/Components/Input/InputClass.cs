using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using System.Globalization;
using System.Linq.Expressions;

namespace QuickKit.Blazor.Components.Input;

public class NumericComponent<T> : RadzenNumeric<T>, INumericComponent<T>
{
    public NumericType Type { get; set; }
}

public class TextBoxComponent : ITextBoxComponent
{
    public string Name { get; set ; }
    public string Placeholder { get; set ; }
    public bool Disabled { get; set ; }
    public bool ReadOnly { get; set ; }
    public bool Trim { get; set ; }
    public long? MaxLength {get; set; }
    public CultureInfo Culture { get; set ; }
    public string Style { get; set ; }
    public bool Visible { get; set ; }
    public string Value { get; set; }
    public Expression<Func<string>> ValueExpression { get; set; }
    public EventCallback<string> ValueChanged { get; set; }
    public EventCallback Change { get; set; }
    public EventCallback MouseEnter { get; set; }
    public EventCallback MouseLeave { get; set; }
    public AutoCompleteType AutoCompleteType { get; set; }
    int? ITextBoxComponent.MaxLength { get; set; }
}
