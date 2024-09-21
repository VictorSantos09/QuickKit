using QuickKit.Blazor.Common.Interfaces.Components.Base;
using Radzen;
using System.Globalization;

namespace QuickKit.Blazor.Components.Input;

public interface IVisible
{
    bool Visible { get; set; }
}

public interface ITValue
{
    public Type TValue { get; set; }
}

public interface ITextBoxComponent : IVisible, IRadzenComponent
{
    string Name { get; set; }
    string Placeholder { get; set; }
    bool Disabled { get; set; }
    bool ReadOnly { get; set; }
    public bool Trim { get; set; }
    long? MaxLength { get; set; }
    CultureInfo Culture { get; set; }
    string Style { get; set; }
}

public interface IDropDownComponent<T> : IVisible, IRadzenComponent
{
    IEnumerable<T> Data { get; set; }
    string Placeholder { get; set; }
    bool Disabled { get; set; }
    bool AllowClear { get; set; }
    bool AllowFiltering { get; set; }
    string TextProperty { get; set; }
    string ValueProperty { get; set; }
    string Style { get; set; }
}

public interface IDatePickerComponent : IVisible, IRadzenComponent
{
    string Placeholder { get; set; }
    bool Disabled { get; set; }
    bool ReadOnly { get; set; }
    CultureInfo Culture { get; set; }
    string Style { get; set; }
}

public interface INumericComponent<T> : IVisible, IRadzenComponent
{
    decimal? Min { get; set; }
    decimal? Max { get; set; }
    string Step { get; set; }
    string Format { get; set; }
    string Placeholder { get; set; }
    bool Disabled { get; set; }
    bool ReadOnly { get; set; }
    string Style { get; set; }
    bool ShowUpDown { get; set; }
    public string Name { get; set; }
    public TextAlign TextAlign { get; set; }
    public NumericType Type { get; set; }

}
public enum NumericType
{
    Int,
    Long,
    Decimal,
    Double,
    Float,
}

public interface ICheckBoxComponent : IVisible, IRadzenComponent
{
    bool Disabled { get; set; }
    bool TriState { get; set; }
    string Style { get; set; }
}

public interface ITextAreaComponent : IVisible, IRadzenComponent
{
    string Placeholder { get; set; }
    int MaxLength { get; set; }
    bool Disabled { get; set; }
    bool ReadOnly { get; set; }
    int Rows { get; set; }
    string Style { get; set; }
}
