using Microsoft.AspNetCore.Components;

namespace QuickKit.Blazor.Common.Interfaces.Components.Events;
#region INTERFACES

public interface IOnValueChanged<T>
{
    public EventCallback<T> ValueChanged { get; set; }
}
#endregion
