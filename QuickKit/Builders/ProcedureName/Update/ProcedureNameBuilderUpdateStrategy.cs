using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Update;

public class ProcedureNameBuilderUpdateStrategy<TEntity> : IProcedureNameBuilderUpdateStrategy where TEntity : IEntity
{
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"sp_{entityName}_update";
    }
}
