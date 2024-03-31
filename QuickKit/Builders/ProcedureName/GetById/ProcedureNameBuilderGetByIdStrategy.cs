using QuickKit.Builders.ProcedureName.Common;
using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.GetById;

/// <summary>
/// Represents a strategy for building the procedure name for the GetById operation.
/// </summary>
public class ProcedureNameBuilderGetByIdStrategy: IProcedureNameBuilderGetByIdStrategy
{
    public string Build<TEntity>() where TEntity : IEntity
    {
        string entityName = ProcedureNameBuilderTextRemover.RemoveEntity<TEntity>();
        return $"SP_{entityName}_GETBYID".ToUpper();
    }
}