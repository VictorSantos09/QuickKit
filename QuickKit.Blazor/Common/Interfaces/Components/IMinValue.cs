namespace QuickKit.Blazor.Common.Interfaces.Components;
#region INTERFACES

interface IMinValue<T> where T : struct
{
    public T MinValue { get; set; }
}
#endregion
