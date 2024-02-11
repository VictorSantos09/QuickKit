using Dapper;
using System.Data;

namespace QuickKit.Extensions.Data;

internal static class DapperExtensions
{

    internal static Task<int> KitExecuteAsync(this IDbConnection conn, CommandDefinition command)
    {
        return conn.ExecuteAsync(command);
    }

    internal static Task<IEnumerable<T>> KitQuery<T>(this IDbConnection conn, CommandDefinition command)
    {
        return conn.QueryAsync<T>(command);
    }

    internal static Task<T?> KitQuerySingleOrDefaultAsync<T>(this IDbConnection conn, CommandDefinition command)
    {
     return conn.QuerySingleOrDefaultAsync<T>(command);
    }
}
