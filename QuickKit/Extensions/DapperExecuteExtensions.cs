using Dapper;
using FluentValidation;
using FluentValidation.Results;
using QuickKit.Shared.Entities;
using System.Data;

namespace QuickKit.Extensions;

/// <summary>
/// Provides extension methods for executing commands using Dapper with additional validation from FluentValidation and transaction support.
/// </summary>
public static class DapperExecuteExtensions
{
    /// <summary>
    /// Executes a database command asynchronously after validating the specified entity using the provided validator.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being validated.</typeparam>
    /// <param name="conn">The database connection.</param>
    /// <param name="entity">The entity to be validated.</param>
    /// <param name="validator">The validator used to validate the entity.</param>
    /// <param name="validationFailureMessage">The error message to be thrown if the validation fails.</param>
    /// <param name="command">The database command to be executed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the number of affected rows.</returns>
    /// <exception cref="ValidationException">Thrown if the validation fails.</exception>
    public static async Task<int> ExecuteValidatingAsync<TEntity>(this IDbConnection conn, TEntity entity,
                                                                  IValidator<TEntity> validator,
                                                                  string validationFailureMessage,
                                                                  CommandDefinition command) where TEntity : IEntity
    {
        ValidationResult result = await validator.ValidateAsync(entity);
        return !result.IsValid
            ? throw new ValidationException(validationFailureMessage, result.Errors)
            : await conn.ExecuteOnTransactionAsync(async () =>
        {
            return await conn.ExecuteAsync(command);
        });
    }

    /// <summary>
    /// Executes the specified command within a transaction on the provided database connection asynchronously.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the command.</typeparam>
    /// <param name="conn">The database connection.</param>
    /// <param name="commandToExecute">The command to execute within the transaction.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the result of the command.</returns>
    public static async Task<TResult> ExecuteOnTransactionAsync<TResult>(this IDbConnection conn, Func<Task<TResult>> commandToExecute)
    {
        conn.Open();
        using IDbTransaction trans = conn.BeginTransaction();
        try
        {
            TResult? result = await commandToExecute();
            trans.Commit();
            return result;
        }
        catch (Exception)
        {
            trans.Rollback();
            throw;
        }
    }

    /// <summary>
    /// Executes the specified command within a transaction asynchronously.
    /// </summary>
    /// <param name="conn">The database connection.</param>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task representing the asynchronous operation. The task result represents the number of rows affected.</returns>
    public static async Task<int> ExecuteOnTransactionAsync(this IDbConnection conn, CommandDefinition command)
    {
        return await conn.ExecuteOnTransactionAsync(async () =>
        {
            return await conn.ExecuteAsync(command);
        });
    }
}
