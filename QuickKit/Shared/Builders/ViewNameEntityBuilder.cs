using QuickKit.Entities;

namespace QuickKit.Shared.Builders;
public class ViewNameEntityBuilder<TEntity> where TEntity : class, IEntityBase
{
    internal static string All => $"{BuilName()}_all";

    private static string BuilName()
    {
        // ex: vw_voluntario_all
        return $"vw_{typeof(TEntity).Name.ToLower().Replace("entity", "")}";
    }
}
