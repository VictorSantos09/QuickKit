using Dapper;
using FluentValidation;
using QuickKit.Shared.Entities;
using System.Data;

namespace QuickKit.Extensions;

public static class DapperExecuteExtensions
{
    public static async Task<int> ExecuteValidatingAsync<TEntity>(this IDbConnection conn, TEntity entity,
                                                                  IValidator<TEntity> validator,
                                                                  string validationFailureMessage,
                                                                  CommandDefinition command) where TEntity : IEntity
    {
        var result = await validator.ValidateAsync(entity);
        if (!result.IsValid)
        {
            throw new ValidationException(validationFailureMessage, result.Errors);
        }

        return await conn.ExecuteOnTransactionAsync(async () =>
        {
            return await conn.ExecuteAsync(command);
        });
    }

    public static async Task<TResult> ExecuteOnTransactionAsync<TResult>(this IDbConnection conn, Func<Task<TResult>> commandToExecute)
    {
        conn.Open();
        using IDbTransaction trans = conn.BeginTransaction();
        try
        {
            var result = await commandToExecute();
            trans.Commit();
            return result;
        }
        catch (Exception)
        {
            trans.Rollback();
            throw;
        }
    }

    public static async Task<int> ExecuteOnTransactionAsync(this IDbConnection conn, CommandDefinition command)
    {
        return await conn.ExecuteOnTransactionAsync(async () =>
        {
            return await conn.ExecuteAsync(command);
        });
    }
}
