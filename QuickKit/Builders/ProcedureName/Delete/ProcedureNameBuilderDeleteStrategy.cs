using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Delete;

/// <summary>
/// Represents a strategy for building the name of a delete stored procedure for a specific entity.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class ProcedureNameBuilderDeleteStrategy<TEntity> : IProcedureNameBuilderDeleteStrategy where TEntity : IEntity
{
    /// <inheritdoc/>
    
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_DELETE".ToUpper();
    }
}
