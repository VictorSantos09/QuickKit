using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Add;

public class ProcedureNameBuilderAddStrategy<TEntity> : IProcedureNameBuilderAddStrategy where TEntity : IEntity
{
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_ADD".ToUpper();
    }
}
