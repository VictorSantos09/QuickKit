using QuickKit.Blazor.Common.Interfaces.Components;
using QuickKit.Blazor.Common.Interfaces.Components.Base;
using QuickKit.Blazor.Common.Interfaces.Components.Events;
using Radzen.Blazor;

namespace QuickKit.Blazor.Components.Input.TextBox;

public interface ITextBoxComponent : IRadzenComponent<RadzenTextBox>, IName, ICulture, IOnValueChanged<string>, IVisible, ITrim, IPlaceholder, IAutoComplete, IStyle, IDisabled, IMaxLength, IMouseLeave, IMouseEnter, IReadoOnly
{
}
