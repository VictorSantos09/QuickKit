using Radzen;

namespace QuickKit.Blazor.Common.Interfaces.Components.Base;
public interface IRadzenComponent<T> : IRadzenComponent where T : RadzenComponent
{

}

public interface IRadzenComponent
{
    
}
