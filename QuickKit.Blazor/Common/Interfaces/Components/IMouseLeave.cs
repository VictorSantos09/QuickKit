using Microsoft.AspNetCore.Components;

namespace QuickKit.Blazor.Common.Interfaces.Components;
#region INTERFACES

public interface IMouseLeave
{
    public EventCallback<ElementReference> MouseLeave { get; set; }
}
#endregion
