using Microsoft.AspNetCore.Components;

namespace QuickKit.Blazor.Common.Interfaces.Components.Events;
#region INTERFACES

interface IOnClickListener<T>
{
    public EventCallback<T> OnClick { get; set; }
}
#endregion
