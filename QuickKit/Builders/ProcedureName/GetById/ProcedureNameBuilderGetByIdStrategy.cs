using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.GetById;

/// <summary>
/// Represents a strategy for building the procedure name for the GetById operation.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class ProcedureNameBuilderGetByIdStrategy<TEntity> : IProcedureNameBuilderGetByIdStrategy where TEntity : IEntity
{
    /// <inheritdoc/>
    public string Build()
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_GETBYID".ToUpper();
    }
}