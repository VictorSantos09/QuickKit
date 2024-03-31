using Classroom.Core.Entities;
using Classroom.Core.Exceptions;
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
using System.Data;

namespace Classroom.Core.Repositories;

public interface IClassroomRepository : IDomainSelfContainedRepository<ClassroomEntity, int>
{
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

    public async Task<int> AddAsync(ClassroomEntity entity, CancellationToken cancellationToken = default)
    {
        CommandDefinition command = new(
            _procedureNameBuilderAddStrategy.Build<ClassroomEntity>(),
            new
            {
                classroom_name = entity.ClassroomName
            },
            cancellationToken: cancellationToken,
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        return await conn.ExecuteValidatingAsync(entity, _validator, "failure", command);
    }

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        CommandDefinition command = new(
            _procedureNameBuilderDeleteStrategy.Build<ClassroomEntity>(),
            new
            {
                idClassroom = id
            },
            cancellationToken: cancellationToken,
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        return await conn.ExecuteOnTransactionAsync(command);
    }

    public async Task<IEnumerable<ClassroomEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        CommandDefinition command = new(
            _procedureNameBuilderGetAllStrategy.Build<ClassroomEntity>(),
            cancellationToken: cancellationToken,
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        IEnumerable<ClassroomSnapshot> result = await conn.QueryAsync<ClassroomSnapshot>(command);
        return result.Select(ClassroomEntity.FromSnapshot);
    }

    public async Task<ClassroomEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        CommandDefinition command = new(
            _procedureNameBuilderGetByStrategy.Build<ClassroomEntity>(),
            new
            {
                id_classroom = id
            },
            cancellationToken: cancellationToken,
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        ClassroomSnapshot? result = await conn.QuerySingleOrDefaultAsync<ClassroomSnapshot>(command);
        return ClassroomEntity.FromSnapshot(result);
    }

    public async Task<ClassroomEntity> GetByIdThrowAsync(int id, string notFoundExceptionMessage, CancellationToken cancellationToken = default)
    {
        return await GetByIdAsync(id) ?? throw new EntityNotFoundException(notFoundExceptionMessage);
    }

    public async Task<int> UpdateAsync(ClassroomEntity entity, CancellationToken cancellationToken = default)
    {
        CommandDefinition command = new(
            _procedureNameBuilderUpdateStrategy.Build<ClassroomEntity>(),
            new
            {
                idClassroom = entity.Id,
                classroomName = entity.ClassroomName
            },
            cancellationToken: cancellationToken,
            commandType: CommandType.StoredProcedure);

        using IDbConnection conn = Connect();
        return await conn.ExecuteOnTransactionAsync(command);
    }
}