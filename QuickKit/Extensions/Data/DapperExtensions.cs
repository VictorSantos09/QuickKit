using Dapper;
using QuickKit.Shared.Constants;
using System.Data;

namespace QuickKit.Extensions.Data;

internal static class DapperExtensions
{
    private static CommandDefinition CreateCommandDefinition(
        string sql,
        object? parameters,
        IDbTransaction? transaction = null,
        CommandType commandType = CommandType.StoredProcedure,
        int commandTimeout = DEFAULT_DATABASE_CNT.DEFAULT_COMMAND_TIMEOUT,
        CommandFlags flags = CommandFlags.Buffered,
        CancellationToken cancellationToken = default)
    {
        return new CommandDefinition(
            sql,
            parameters,
            transaction,
            commandTimeout,
            commandType,
            flags,
            cancellationToken);
    }

    internal static Task<int> SLExecuteAsync(
        this IDbConnection conn,
        string procedureName,
        object? parameters,
        IDbTransaction? transaction = null,
        int commandTimeout = DEFAULT_DATABASE_CNT.DEFAULT_COMMAND_TIMEOUT,
        CommandFlags flags = CommandFlags.Buffered,
        CancellationToken cancellationToken = default)
    {
        var command = CreateCommandDefinition(
            procedureName,
            parameters,
            transaction,
            CommandType.StoredProcedure,
            commandTimeout,
            flags,
            cancellationToken);

        return conn.ExecuteAsync(command);
    }

    internal static Task<IEnumerable<T>> SLQuery<T>(
        this IDbConnection conn,
        string procedureName,
        object? parameters,
        int commandTimeout = DEFAULT_DATABASE_CNT.DEFAULT_COMMAND_TIMEOUT,
        CommandFlags flags = CommandFlags.Buffered,
        CancellationToken cancellationToken = default)
    {

        var command = CreateCommandDefinition(
            procedureName,
            parameters,
            null,
            CommandType.StoredProcedure,
            commandTimeout,
            flags,
            cancellationToken);

        return conn.QueryAsync<T>(command);
    }

    internal static Task<T?> SLQuerySingleOrDefaultAsync<T>(
        this IDbConnection conn,
        string procedureName,
        object? parameters,
        IDbTransaction? transaction = null,
        int commandTimeout = DEFAULT_DATABASE_CNT.DEFAULT_COMMAND_TIMEOUT,
        CommandFlags flags = CommandFlags.Buffered,
        CancellationToken cancellationToken = default)
    {
        var command = CreateCommandDefinition(
            procedureName,
            parameters,
            transaction,
            CommandType.StoredProcedure,
            commandTimeout,
            flags,
            cancellationToken);

        return conn.QuerySingleOrDefaultAsync<T>(command);
    }
}
