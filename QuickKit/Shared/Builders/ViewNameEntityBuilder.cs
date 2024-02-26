using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Builders;

/// <summary>
/// Represents a builder class for generating view names for entities.
/// <para>Remove the "Entity" suffix from the entity type name and convert it to lowercase.</para>
/// <para>These names are used to call the views in the database.</para>
/// <para>Example: For a view for all VoluntarioEntity, the output would be "vw_voluntario_all"</para>
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class ViewNameEntityBuilder<TEntity> where TEntity : IEntity
{
    /// <summary>
    /// Gets the view name for all entities.
    /// </summary>
    public static string All => $"{BuilName()}_all";

    private static string BuilName()
    {
        // ex: vw_voluntario_all
        return $"vw_{typeof(TEntity).Name.ToLower().Replace("entity", "")}";
    }
}
