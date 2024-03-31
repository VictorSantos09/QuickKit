using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Delete;

/// <summary>
/// Represents a strategy for building the name of a delete stored procedure for a specific entity.
/// </summary>
public class ProcedureNameBuilderDeleteStrategy : IProcedureNameBuilderDeleteStrategy
{
    /// <inheritdoc/>

    public string Build<TEntity>() where TEntity : IEntity
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_DELETE".ToUpper();
    }
}
