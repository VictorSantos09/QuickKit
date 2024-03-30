using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Common;
/// <summary>
/// Represents a strategy for building procedure names for entities.
/// </summary>
public interface IProcedureNameBuilderStrategy
{
    /// <summary>
    /// Builds the procedure name.
    /// </summary>
    /// <returns>The procedure name as a string.</returns>
    public string Build<TEntity>() where TEntity : IEntity;
}