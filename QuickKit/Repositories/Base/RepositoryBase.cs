using Dapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QuickKit.Entities;
using QuickKit.Exceptions;
using QuickKit.Extensions.Data;
using QuickKit.Shared.Builders;
using QuickKit.Shared.Constants;
using QuickKit.Shared.Handlers;
using QuickKit.Validations.Extensions;
using System.Data;

namespace QuickKit.Repositories.Base;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
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
    public abstract Task<int> DeleteAsync(int id);
    public abstract Task<TEntity?> GetByIdAsync(int id);

    public async Task<TEntity> GetByIdThrowAsync(int id, string notFoundExceptionMessage)
    {
        return await GetByIdAsync(id) ?? throw new NotFoundException(notFoundExceptionMessage);
    }

    protected async Task<bool> ExistsAsync(int id)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.QuerySingleAsync<bool>(
                ProcedureNameEntityBuilder<TEntity>.ExistsById(),
                new { id },
                commandTimeout: DEFAULT_DATABASE_CNT.DEFAULT_COMMAND_TIMEOUT);
        }
    }

    protected virtual IDbConnection ConnectToDatabase()
    {
        return _handler.ConnectToMySQL();
    }

    protected virtual async Task<int> ExecuteOnDatabaseAsync(string procedureName, object? parameters)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await ExecuteOnTransactionAsync(conn, async () =>
            {
                return await conn.SLExecuteAsync(procedureName, parameters);
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

    protected async Task<int> ExecuteAsync(TEntity entity, string procedureName, object? parameters, string validationFailureMessage)
    {
        await _validator.ValidateThrowAsync(entity, validationFailureMessage);
        return await ExecuteOnDatabaseAsync(procedureName, parameters);
    }

    protected async Task<int> ExecuteIfExistsAsync(int id, string procedureName, string notFoundExceptionMessage, object? parameters)
    {
        if (!await ExistsAsync(id)) throw new NotFoundException(notFoundExceptionMessage);
        return await ExecuteOnDatabaseAsync(procedureName, parameters);
    }

    protected async Task<IEnumerable<TResult>> QueryAsync<TResult>(string procedureName, object? parameters = null)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.SLQuery<TResult>(procedureName, parameters);
        }
    }

    protected async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string procedureName, object? parameters = null)
    {
        using (IDbConnection conn = ConnectToDatabase())
        {
            return await conn.SLQuerySingleOrDefaultAsync<TResult>(procedureName, parameters);
        }
    }
}
