using Dapper;
using System.Data;

namespace QuickKit.Extensions.Data;

/// <summary>
/// Contains extension methods for Dapper related operations.
/// </summary>
internal static class DapperExtensions
{
    /// <summary>
    /// Executes a command asynchronously on the database connection.
    /// </summary>
    /// <param name="conn">The database connection.</param>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task representing the asynchronous operation, returning the number of affected rows.</returns>
    internal static Task<int> ExecuteAsyncKit(this IDbConnection conn, CommandDefinition command)
    {
        return conn.ExecuteAsync(command);
    }

    /// <summary>
    /// Executes a query asynchronously on the database connection and returns the results as a collection of objects.
    /// </summary>
    /// <typeparam name="T">The type of objects to return.</typeparam>
    /// <param name="conn">The database connection.</param>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task representing the asynchronous operation, returning the collection of objects.</returns>
    internal static Task<IEnumerable<T>> QueryAsyncKit<T>(this IDbConnection conn, CommandDefinition command)
    {
        return conn.QueryAsync<T>(command);
    }

    /// <summary>
    /// Executes a query asynchronously on the database connection and returns the first result or a default value if no results are found.
    /// </summary>
    /// <typeparam name="T">The type of object to return.</typeparam>
    /// <param name="conn">The database connection.</param>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task representing the asynchronous operation, returning the first result or a default value.</returns>
    internal static Task<T?> QuerySingleOrDefaultAsyncKit<T>(this IDbConnection conn, CommandDefinition command)
    {
        return conn.QuerySingleOrDefaultAsync<T>(command);
    }
}
