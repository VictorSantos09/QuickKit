using Radzen.Blazor;

namespace QuickKit.Blazor.Components.Input;

public class NumericComponent<T> : RadzenNumeric<T>, INumericComponent<T>
{
    public NumericType Type { get; set; }
}

public class TextBoxComponent : RadzenTextBox, ITextBoxComponent
{
}
