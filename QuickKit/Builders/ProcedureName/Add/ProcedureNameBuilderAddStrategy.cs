using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Add;

/// <summary>
/// Represents a strategy for building the name of a stored procedure used for adding entities.
/// </summary>
public class ProcedureNameBuilderAddStrategy : IProcedureNameBuilderAddStrategy
{
    /// <inheritdoc/>

    public string Build<TEntity>() where TEntity : IEntity
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_ADD".ToUpper();
    }
}
