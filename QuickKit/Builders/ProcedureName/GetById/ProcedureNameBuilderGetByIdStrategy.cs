using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.GetById;

public class ProcedureNameBuilderGetByIdStrategy<TEntity> : IProcedureNameBuilderGetByIdStrategy where TEntity : IEntity
{
    public string Build()
    {

        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"sp_{entityName}_getById";
    }
}