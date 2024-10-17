using Microsoft.AspNetCore.Components;
using QuickKit.Blazor.Common.Interfaces.Components.Base;
using QuickKit.Blazor.Components.Grid;
using Radzen;
using Radzen.Blazor;
using System.Globalization;
using System.Linq.Expressions;

namespace QuickKit.Blazor.Components.Input;

public class FieldConfig
{
    public string PropertyName { get; set; }
    public string? Label { get; set; }
    public string? Placeholder { get; set; }
    public bool IsRequired { get; set; } = true;
    public int? MaxLength { get; set; }
    public bool IsReadOnly { get; set; }
    public bool IsDisabled { get; set; }
    public RadzenFormInputType InputType { get; set; }
    public string ValidationMessage { get; set; } = "Campo obrigatório";
    public string? Value { get; set; }
    public IEnumerable<string> Values { get; set; }
    public string Style { get; set; } = "display: block; width: 100%;";
    public string Name { get; set; }
    public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;
    public bool Disabled { get; set; }
    public bool ReadOnly { get; set; }
    public bool Trim { get; set; }
    public bool Visible { get; set; } = true;
    public string ValueChanged { get; set; }
    public bool AllowClear { get; set; } = true;
    public bool AllowFiltering { get; set; } = true;
    public string TextProperty { get; set; }
    public string ValueProperty { get; set; }
    public string TValue { get; set; }
    public string Max { get; set; }
    public string Min { get; set; }
    public string Step { get; set; }
    public string Format { get; set; }
    public string TriState { get; set; }
    public AutoCompleteType AutoCompleteType { get; set; } = AutoCompleteType.Off;
    public IEnumerable<string> Data { get; set; }
    public bool AllowSelectAll { get; set; }
    public bool AllowVirtualization {get; set;}
    public bool Chips { get; set; } = true;
    public bool ClearSearchAfterSelection { get; set; } = true;
    public int Count {get; set;}
    public string DisabledProperty {get; set;}
    public string EmptyAriaLabel {get; set;}
    public bool FilterAsYouType { get; set; } = true;
    public FilterCaseSensitivity FilterCaseSensitivity {get; set;} = FilterCaseSensitivity.CaseInsensitive;
    public int FilterDelay { get; set; } = 50;
    public StringFilterOperator FilterOperator { get; set; } = StringFilterOperator.Contains;
    public string FilterPlaceholder { get; set; } = "Filtrar";
    public int MaxSelectedLabels {get; set;}
    public bool Multiple {get; set;}
    public int PageSize {get; set;}
    public bool OpenOnFocus {get; set;}
    public string PopupStyle {get; set;}
    public string RemoveChipTitle {get; set;}
    public string SearchAriaLabel { get; set; } = "Pesquisar";
    public string SearchText { get; set; }
    public string SelectAllText { get; set; } = "Selecionar todos";
    public object SelectedItem { get; set; }
    public EventCallback<object> SelectedItemChanged {get; set;}
    public string SelectedItemsText { get; set; } = "Itens selecionados";
    public string Separator {get; set;}
    public int Rows { get; set; } = 10;
    public int Cols { get; set; } = 50;
    public bool AllowInput { get; set; } = true;
    public string CalendarWeekTitle { get; set; } = "Semana";
    public string DateFormat { get; set; } = "dd/MM/yyyy h:mm tt";
    public string HourFormat { get; set; } = "12";
    public string HoursStep {get; set;}
    public DateTime InitialViewDate { get; set; } = DateTime.Now;
    public bool Inline { get; set; } = true;
    public DateTimeKind Kind {get; set;} = DateTimeKind.Local;
    public DateTime MaxDate {get; set;} = DateTime.MaxValue;
    public DateTime MinDate { get; set; } = DateTime.MinValue;
    public string MinutesStep {get; set;}
    public string NextMonthAriaLabel { get; set; } = "Próximo mês";
    public string OkAriaLabel { get; set; } = "Ok";
    public bool PadHours {get; set;}
    public bool PadMinutes {get; set;}
    public bool PadSeconds {get; set;}
    public Func<string, DateTime?> ParseInput {get; set;}
    public string PrevMonthAriaLabel { get; set; } = "Mês anterior";
    public string SecondsStep {get; set;}
    public string YearRange {get; set;}
    public string ToggleAriaLabel {get; set;}
    public string ToggleAmPmAriaLabel {get; set;}
    public bool TimeOnly {get; set;}
    public bool ShowTimeOkButton { get; set; } = true;
    public bool ShowTime {get; set;}
    public bool ShowSeconds {get; set;}
    public bool ShowDays { get; set; } = true;
    public bool ShowCalendarWeek { get; set; } = true;
    public bool ShowButton { get; set; } = true;
    public PopupRenderMode PopupRenderMode { get; set; } = PopupRenderMode.OnDemand;

    public FieldConfig()
    {
        if (AllowSelectAll)
        {
            Multiple = true;
        }
    }
}

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
    string Value { get; set; }
    string Placeholder { get; set; }
    bool Disabled { get; set; }
    int? MaxLength { get; set; }
    CultureInfo Culture { get; set; }
    bool ReadOnly { get; set; }
    string Style { get; set; }
    bool Trim { get; set; }
    bool Visible { get; set; }
    public AutoCompleteType AutoCompleteType { get; set; }
    Expression<Func<string>> ValueExpression { get; set; }
    EventCallback<string> ValueChanged { get; set; }
    EventCallback Change { get; set; }
    EventCallback MouseEnter { get; set; }
    EventCallback MouseLeave { get; set; }
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
