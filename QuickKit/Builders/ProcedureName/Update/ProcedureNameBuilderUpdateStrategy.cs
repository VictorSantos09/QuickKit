using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Update;

/// <summary>
/// Represents a strategy for building the name of an update stored procedure for a specific entity.
/// </summary>
public class ProcedureNameBuilderUpdateStrategy : IProcedureNameBuilderUpdateStrategy
{
    /// <inheritdoc/>
    public string Build<TEntity>() where TEntity : IEntity
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_UPDATE".ToUpper();
    }
}
