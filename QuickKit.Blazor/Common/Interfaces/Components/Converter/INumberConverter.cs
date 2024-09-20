namespace QuickKit.Blazor.Common.Interfaces.Components.Converter;

#region INTERFACES
#endregion

#region Radzen

interface INumberConverter<T> where T : struct
{
    public Func<string, T> Convert { get; set; }
}
#endregion
