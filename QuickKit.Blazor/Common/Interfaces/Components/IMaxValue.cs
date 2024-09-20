namespace QuickKit.Blazor.Common.Interfaces.Components;

interface IMaxValue<T> where T : struct
{
    public T MaxValue { get; set; }
}
