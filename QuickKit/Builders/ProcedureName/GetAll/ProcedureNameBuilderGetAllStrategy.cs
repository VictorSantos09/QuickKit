using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.GetAll;

/// <summary>
/// Represents a strategy for building the procedure name for getting all entities of a specific type.
/// </summary>
public class ProcedureNameBuilderGetAllStrategy : IProcedureNameBuilderGetAllStrategy
{
    public string Build<TEntity>() where TEntity : IEntity
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_GETALL".ToUpper();
    }
}
