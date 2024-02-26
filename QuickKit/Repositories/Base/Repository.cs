using Dapper;
using FluentValidation;
using QuickKit.Extensions.Data;
using QuickKit.Shared.Builders;
using QuickKit.Shared.Entities;
using QuickKit.Shared.Exceptions;
using QuickKit.Shared.Handlers;
using QuickKit.Shared.Validations.Extensions;
using System.Data;

namespace QuickKit.Repositories.Base;

/// <summary>
/// Base class for repositories that provides common functionality for CRUD operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
public abstract class Repository<TEntity, TKey> 
    where TEntity : IEntity 
    where TKey : IConvertible
{
    protected static readonly string ProcedureNameAdd = ProcedureNameEntityBuilder<TEntity>.Add;
    protected static readonly string ProcedureNameDelete = ProcedureNameEntityBuilder<TEntity>.Delete;
    protected static readonly string ProcedureNameUpdate = ProcedureNameEntityBuilder<TEntity>.Update;
    protected static readonly string ProcedureNameGetAll = ProcedureNameEntityBuilder<TEntity>.GetAll;
    protected static readonly string ProcedureNameGetById = ProcedureNameEntityBuilder<TEntity>.GetById;

    private readonly IValidator<TEntity> _validator;
    private readonly IDatabaseConnectionHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{TEntity, TKey}"/> class.
    /// </summary>
    /// <param name="validator">The validator used for entity validation.</param>
    /// <param name="handler">The database connection handler.</param>
    protected Repository(IValidator<TEntity> validator, IDatabaseConnectionHandler handler)
    {
        _validator = validator;
        _handler = handler;
    }

    #region Abstract Methods

    /// <inheritdoc/>
    public abstract Task<IEnumerable<TEntity>> GetAllAsync();

    /// <inheritdoc/>
    public abstract Task<int> AddAsync(TEntity entity);

    /// <inheritdoc/>
    public abstract Task<int> UpdateAsync(TEntity entity);

    /// <inheritdoc/>
    public abstract Task<int> DeleteAsync(TKey id);

    /// <inheritdoc/>
    public abstract Task<TEntity?> GetByIdAsync(TKey id);

    #endregion

    /// <inheritdoc/>
    public virtual async Task<TEntity> GetByIdThrowAsync(TKey id, string notFoundExceptionMessage)
    {
        return await GetByIdAsync(id) ?? throw new NotFoundException(notFoundExceptionMessage);
    }

    /// <summary>
    /// Checks if a record exists in the database based on the given command.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating if the record exists.</returns>
    protected async Task<bool> ExistsAsync(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.QuerySingleAsync<bool>(command);
        }
    }

    /// <summary>
    /// Connects to the database.
    /// </summary>
    /// <returns>The database connection.</returns>
    protected virtual IDbConnection ConnectToDatabase()
    {
        return _handler.Connect();
    }

    #region Execute

    /// <summary>
    /// Executes a command on the database asynchronously.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
    protected virtual async Task<int> ExecuteOnDatabaseAsync(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await ExecuteOnTransactionAsync(conn, async () =>
            {
                return await conn.ExecuteAsyncKit(command);
            });
        }
    }

    /// <summary>
    /// Executes a command on the database within a transaction asynchronously.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="conn">The database connection.</param>
    /// <param name="commandToExecute">The command to execute within the transaction.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the command.</returns>
    protected virtual async Task<TResult> ExecuteOnTransactionAsync<TResult>(IDbConnection conn, Func<Task<TResult>> commandToExecute)
    {
        conn.Open();
        using (IDbTransaction trans = conn.BeginTransaction())
        {
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
    }

    /// <summary>
    /// Executes a command on the database asynchronously after validating the entity.
    /// </summary>
    /// <param name="entity">The entity to validate.</param>
    /// <param name="command">The command to execute.</param>
    /// <param name="validationFailureMessage">The validation failure message to use if the entity is not valid.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
    protected async Task<int> ExecuteAsync(TEntity entity, CommandDefinition command, string validationFailureMessage)
    {
        await _validator.ValidateThrowAsync(entity, validationFailureMessage);
        return await ExecuteOnDatabaseAsync(command);
    }

    #endregion

    #region Query

    /// <summary>
    /// Executes a query on the database asynchronously and returns the results as a collection of <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of results.</returns>
    protected async Task<IEnumerable<TResult>> QueryAsync<TResult>(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.QueryAsyncKit<TResult>(command);
        }
    }

    /// <summary>
    /// Executes a query on the database asynchronously and returns the first result as <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="command">The command to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the first result, or null if not found.</returns>
    protected async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.QuerySingleOrDefaultAsyncKit<TResult>(command);
        }
    }

    #endregion
}
