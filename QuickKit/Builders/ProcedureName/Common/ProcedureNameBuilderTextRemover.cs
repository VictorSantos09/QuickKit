using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Common;
public static class ProcedureNameBuilderTextRemover
{
    public static string RemoveEntity<TEntity>(StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        where TEntity : IEntity
    {
        return $"{typeof(TEntity).Name.Replace("entity", "", stringComparison)}";
    }
}
