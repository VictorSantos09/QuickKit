using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.GetAll;

public class ProcedureNameBuilderGetAllStrategy<TEntity> : IProcedureNameBuilderGetAllStrategy where TEntity : IEntity
{
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_GETALL".ToUpper();
    }
}
