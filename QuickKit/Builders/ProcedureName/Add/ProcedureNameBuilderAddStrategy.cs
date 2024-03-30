using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Add;

/// <summary>
/// Represents a strategy for building the name of a stored procedure used for adding entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public class ProcedureNameBuilderAddStrategy<TEntity> : IProcedureNameBuilderAddStrategy where TEntity : IEntity
{
    /// <inheritdoc/>

    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_ADD".ToUpper();
    }
}
