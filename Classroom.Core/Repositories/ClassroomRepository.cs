using Classroom.Core.Entities;
using Dapper;
using FluentValidation;
using QuickKit.Repositories.Base;
using QuickKit.Shared.Handlers;
using System.Data;

namespace Classroom.Core.Repositories
{
    public interface IClassroomRepository : IRepository<ClassroomEntity, int>
    {
    }

    public class ClassroomRepository : Repository<ClassroomEntity, int>,  IClassroomRepository
    {
        public ClassroomRepository(IValidator<ClassroomEntity> validator,
            IDatabaseConnectionHandler handler) : base(validator, handler)
        {
        }

        public override async Task<int> AddAsync(ClassroomEntity entity)
        {
            CommandDefinition command = new(
                ProcedureNameAdd,
                new
                {
                  classroom_name =  entity.ClassroomName
                },
                commandType: CommandType.StoredProcedure);

            return await ExecuteAsync(entity, command, $"{entity} is not valid");
        }

        public override async Task<int> DeleteAsync(int id)
        {
            CommandDefinition command = new(
                ProcedureNameDelete,
                new
                {
                    idClassroom = id
                },
                commandType: CommandType.StoredProcedure);

            return await ExecuteAsync(command);
        }

        public override async Task<IEnumerable<ClassroomEntity>> GetAllAsync()
        {
            CommandDefinition command = new(
                ProcedureNameGetAll,
                commandType: CommandType.StoredProcedure);

            var result = await QueryAsync<ClassroomSnapshot>(command);
            return result.Select(ClassroomEntity.FromSnapshot);
        }

        public override async Task<ClassroomEntity?> GetByIdAsync(int id)
        {
            CommandDefinition command = new(
                ProcedureNameGetById,
                new
                {
                    id_classroom = id
                },
                commandType: CommandType.StoredProcedure);

            var result = await QuerySingleOrDefaultAsync<ClassroomSnapshot>(command);
            return ClassroomEntity.FromSnapshot(result);
        }

        public override async Task<int> UpdateAsync(ClassroomEntity entity)
        {
            CommandDefinition command = new(
                ProcedureNameUpdate,
                new
                {
                   idClassroom = entity.Id,
                   classroomName = entity.ClassroomName
                },
                commandType: CommandType.StoredProcedure);

            return await ExecuteAsync(command);
        }
    }
}
