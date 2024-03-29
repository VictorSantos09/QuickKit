using Classroom.Core.Entities;
using Classroom.Core.Repositories.Common;
using Dapper;
using FluentValidation;
using MySql.Data.MySqlClient;
using QuickKit.Builders.ProcedureName.Add;
using QuickKit.Builders.ProcedureName.Delete;
using QuickKit.Builders.ProcedureName.GetAll;
using QuickKit.Builders.ProcedureName.GetById;
using QuickKit.Builders.ProcedureName.Update;
using QuickKit.Extensions;
using QuickKit.Shared.Exceptions;
using System.Data;

namespace Classroom.Core.Repositories;

public interface IClassroomRepository : IDomainSelfContainedRepository<ClassroomEntity, int>
{
    Task<IQueryable<ClassroomEntity>> GetAllPagedAsync();
}

public class ClassroomRepository : IClassroomRepository
{
    private readonly IValidator<ClassroomEntity> _validator;
    private readonly IProcedureNameBuilderDeleteStrategy _procedureNameBuilderDeleteStrategy;
    private readonly IProcedureNameBuilderAddStrategy _procedureNameBuilderAddStrategy;
    private readonly IProcedureNameBuilderGetAllStrategy _procedureNameBuilderGetAllStrategy;
    private readonly IProcedureNameBuilderGetByIdStrategy _procedureNameBuilderGetByStrategy;
    private readonly IProcedureNameBuilderUpdateStrategy _procedureNameBuilderUpdateStrategy;

    public ClassroomRepository(
        IValidator<ClassroomEntity> validator,
        IProcedureNameBuilderDeleteStrategy procedureNameBuilderDeleteStrategy,
        IProcedureNameBuilderAddStrategy procedureNameBuilderAddStrategy,
        IProcedureNameBuilderGetAllStrategy procedureNameBuilderGetAllStrategy,
        IProcedureNameBuilderGetByIdStrategy procedureNameBuilderGetByStrategy,
        IProcedureNameBuilderUpdateStrategy procedureNameBuilderUpdateStrategy)
    {
        _validator = validator;
        _procedureNameBuilderDeleteStrategy = procedureNameBuilderDeleteStrategy;
        _procedureNameBuilderAddStrategy = procedureNameBuilderAddStrategy;
        _procedureNameBuilderGetAllStrategy = procedureNameBuilderGetAllStrategy;
        _procedureNameBuilderGetByStrategy = procedureNameBuilderGetByStrategy;
        _procedureNameBuilderUpdateStrategy = procedureNameBuilderUpdateStrategy;
    }

    protected static IDbConnection Connect()
    {
        return new MySqlConnection("Server=localhost;Database=quickkit_demo;Uid=root;Pwd=root;");
    }

    public async Task<int> AddAsync(ClassroomEntity entity)
    {
        CommandDefinition command = new(
            _procedureNameBuilderAddStrategy.Build(),
            new
            {
                classroom_name = entity.ClassroomName
            },
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        return await conn.ExecuteValidatingAsync(entity, _validator, "failure", command);
    }

    public async Task<int> DeleteAsync(int id)
    {
        CommandDefinition command = new(
            _procedureNameBuilderDeleteStrategy.Build(),
            new
            {
                idClassroom = id
            },
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        return await conn.ExecuteOnTransactionAsync(command);
    }

    public async Task<IEnumerable<ClassroomEntity>> GetAllAsync()
    {
        CommandDefinition command = new(
            _procedureNameBuilderGetAllStrategy.Build(),
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        var result = await conn.QueryAsync<ClassroomSnapshot>(command);
        return result.Select(ClassroomEntity.FromSnapshot);
    }

    public async Task<IQueryable<ClassroomEntity>> GetAllPagedAsync()
    {
        CommandDefinition command = new(
            _procedureNameBuilderGetAllStrategy.Build(),
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        var result = await conn.QueryAsync<ClassroomSnapshot>(command);
        return result.Select(ClassroomEntity.FromSnapshot).AsQueryable();
    }

    public async Task<ClassroomEntity?> GetByIdAsync(int id)
    {
        CommandDefinition command = new(
            _procedureNameBuilderGetByStrategy.Build(),
            new
            {
                id_classroom = id
            },
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        var result = await conn.QuerySingleOrDefaultAsync<ClassroomSnapshot>(command);
        return ClassroomEntity.FromSnapshot(result);
    }

    public async Task<ClassroomEntity> GetByIdThrowAsync(int id, string notFoundExceptionMessage)
    {
        return await GetByIdAsync(id) ?? throw new EntityNotFoundException(notFoundExceptionMessage);
    }

    public async Task<int> UpdateAsync(ClassroomEntity entity)
    {
        CommandDefinition command = new(
            _procedureNameBuilderUpdateStrategy.Build(),
            new
            {
                idClassroom = entity.Id,
                classroomName = entity.ClassroomName
            },
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        return await conn.ExecuteOnTransactionAsync(command);
    }
}