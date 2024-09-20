using Microsoft.AspNetCore.Components;

namespace QuickKit.Blazor.Common.Interfaces.Components;
#region INTERFACES

public interface IMouseEnter
{
    public EventCallback<ElementReference> MouseEnter { get; set; }
}
#endregion
