using Radzen;

namespace QuickKit.Blazor.Components.Grid;

public class GridColumn
{
    public string Title { get; set; }
    public string PropertyName { get; set; }
    public bool Frozen { get; set; }
    public bool Filterable { get; set; } = true;
    public bool Groupable { get; set; } = true;
    public bool Pickable { get; set; } = true;
    public bool Reorderable { get; set; } = true;
    public bool Resizable { get; set; } = true;
    public bool Sortable { get; set; } = true;
    public bool Visible { get; set; } = true;
    public string Width { get; }
    public TextAlign TextAlign { get; }
    public string? UniqueID { get; set; } = null;
    public string? ColumnPickerTitle { get; set; } = null;

    public GridColumn(string title,
                        string propertyName,
                        string? uniqueID = null,
                        string? columnPickerTitle = null,
                        bool frozen = false,
                        bool filterable = true,
                        bool groupable = true,
                        bool pickable = true,
                        bool reorderable = true,
                        bool resizable = true,
                        bool sortable = true,
                        bool visible = true,
                        string width = "80px",
                        TextAlign textAlign = TextAlign.Center)
    {
        Title = title;
        PropertyName = propertyName;
        Frozen = frozen;
        Filterable = filterable;
        Groupable = groupable;
        Pickable = pickable;
        Reorderable = reorderable;
        Resizable = resizable;
        Sortable = sortable;
        Visible = visible;
        Width = width;
        TextAlign = textAlign;
        UniqueID = uniqueID;
        ColumnPickerTitle = columnPickerTitle;
    }
}

public enum RadzenFormInputType
{
    Button,
    ToggleButton,
    CheckBox,
    CheckBoxList,
    ColorPicker,
    DatePicker,
    DropDown,
    DropDownDataGrid,
    FieldSet,
    FileInput,
    FormField,
    HtmlEditor,
    ListBox,
    Mask,
    Numeric,
    Password,
    RadioButtonList,
    Rating,
    SecurityCode,
    Slider,
    SpeechToTextButton,
    SpitButton,
    Switch,
    TemplateForm,
    TextArea,
    TextBox,
    Upload
}
