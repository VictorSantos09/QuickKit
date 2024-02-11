using Dapper;
using FluentValidation;
using QuickKit.Entities;
using QuickKit.Exceptions;
using QuickKit.Extensions.Data;
using QuickKit.Shared.Builders;
using QuickKit.Shared.Handlers;
using QuickKit.Validations.Extensions;
using System.Data;

namespace QuickKit.Repositories.Base;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntityBase where TKey : struct
{
    protected static readonly string ProcedureNameAdd = ProcedureNameEntityBuilder<TEntity>.Add;
    protected static readonly string ProcedureNameDelete = ProcedureNameEntityBuilder<TEntity>.Delete;
    protected static readonly string ProcedureNameUpdate = ProcedureNameEntityBuilder<TEntity>.Update;
    protected static readonly string ProcedureNameGetAll = ProcedureNameEntityBuilder<TEntity>.GetAll;
    protected static readonly string ProcedureNameGetById = ProcedureNameEntityBuilder<TEntity>.GetById;

    private readonly IValidator<TEntity> _validator;
    private readonly DatabaseConnectionHandler _handler;

    protected RepositoryBase(IValidator<TEntity> validator, DatabaseConnectionHandler handler)
    {
        _validator = validator;
        _handler = handler;
    }

    public abstract Task<IEnumerable<TEntity>> GetAllAsync();
    public abstract Task<int> AddAsync(TEntity entity);
    public abstract Task<int> UpdateAsync(TEntity entity);
    public abstract Task<int> DeleteAsync(TKey id);
    public abstract Task<TEntity?> GetByIdAsync(TKey id);

    public async Task<TEntity> GetByIdThrowAsync(TKey id, string notFoundExceptionMessage)
    {
        return await GetByIdAsync(id) ?? throw new NotFoundException(notFoundExceptionMessage);
    }

    protected async Task<bool> ExistsAsync(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.QuerySingleAsync<bool>(command);
        }
    }

    protected virtual IDbConnection ConnectToDatabase()
    {
        return _handler.ConnectToMySQL();
    }

    protected virtual async Task<int> ExecuteOnDatabaseAsync(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await ExecuteOnTransactionAsync(conn, async () =>
            {
                return await conn.KitExecuteAsync(command);
            });
        }
    }

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

    protected async Task<int> ExecuteAsync(TEntity entity, CommandDefinition command,
                                           string validationFailureMessage)
    {
        await _validator.ValidateThrowAsync(entity, validationFailureMessage);
        return await ExecuteOnDatabaseAsync(command);
    }

    protected async Task<IEnumerable<TResult>> QueryAsync<TResult>(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.KitQuery<TResult>(command);
        }
    }

    protected async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(CommandDefinition command)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.KitQuerySingleOrDefaultAsync<TResult>(command);
        }
    }
}
