using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.GetAll;

/// <summary>
/// Represents a strategy for building the procedure name for getting all entities of a specific type.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class ProcedureNameBuilderGetAllStrategy<TEntity> : IProcedureNameBuilderGetAllStrategy where TEntity : IEntity
{
    /// <inheritdoc/>
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_GETALL".ToUpper();
    }
}
