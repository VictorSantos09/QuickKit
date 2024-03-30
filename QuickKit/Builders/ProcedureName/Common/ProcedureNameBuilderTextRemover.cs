using QuickKit.Shared.Entities;

namespace QuickKit.Builders.ProcedureName.Common;
/// <summary>
/// Provides methods to remove specific text from the name of an entity type.
/// </summary>
public static class ProcedureNameBuilderTextRemover
{
    /// <summary>
    /// Removes the word "entity" from the name of the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="stringComparison">The string comparison option to use when removing the word "entity".</param>
    /// <returns>The name of the entity type with the word "entity" removed.</returns>
    public static string RemoveEntity<TEntity>(StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        where TEntity : IEntity
    {
        return $"{typeof(TEntity).Name.Replace("entity", "", stringComparison)}";
    }
}
