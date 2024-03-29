using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Delete;

public class ProcedureNameBuilderDeleteStrategy<TEntity> : IProcedureNameBuilderDeleteStrategy where TEntity : IEntity
{
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"sp_{entityName}_delete";
    }
}
