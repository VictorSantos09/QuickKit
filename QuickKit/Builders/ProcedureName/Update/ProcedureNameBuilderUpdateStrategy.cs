using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Update;

/// <summary>
/// Represents a strategy for building the name of an update stored procedure for a specific entity.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class ProcedureNameBuilderUpdateStrategy<TEntity> : IProcedureNameBuilderUpdateStrategy where TEntity : IEntity
{
    /// <inheritdoc/>
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_UPDATE".ToUpper();
    }
}
