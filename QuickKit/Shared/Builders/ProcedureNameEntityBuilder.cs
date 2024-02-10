using QuickKit.Entities;

namespace QuickKit.Shared.Builders;
public class ProcedureNameEntityBuilder<TEntity> where TEntity : class, IEntityBase
{
    public static string Add => $"{BuildName()}_add";
    public static string Update => $"{BuildName()}_update";
    public static string Delete => $"{BuildName()}_delete";
    public static string GetAll => $"{BuildName()}_getAll";
    public static string GetById => $"{BuildName()}_getById";

    private static string BuildName()
    {
        return $"sp_{typeof(TEntity).Name.ToLower().Replace("entity", "")}";
    }

    public static string ExistsById()
    {
        return $"{BuildName()}_existsById";
    }
}
