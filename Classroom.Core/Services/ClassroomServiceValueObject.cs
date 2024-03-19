using Classroom.Core.Entities;
using Classroom.Core.Repositories;
using QuickKit.Shared.Extensions;

namespace Classroom.Core.Services
{
    public interface IClassroomServiceValueObject : IServiceValueObject<ClassroomEntity, int> { }

    public class ClassroomServiceValueObject : IClassroomServiceValueObject
    {
        private readonly IClassroomRepository _repository;

        public ClassroomServiceValueObject(IClassroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddAsync(ClassroomEntity entity)
        {
            if (entity.IsNull()) return Result.Failure("classroom.Null", "classroom can't be null");

            var result = await _repository.AddAsync(entity);

            if (result <= 0) return Result.Failure("classroom.Failure", "entity not saved");

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id)
        {
            if (id <= 0) return Result.Failure("classroom.invalidId", "id not valid");

            var result = await _repository.DeleteAsync(id);

            if (result > 0) return Result.Success();
            return Result.Failure("classroom.deleteFail", "delete fail");
        }

        public async Task<Result<IEnumerable<ClassroomEntity>>> GetAllAsync()
        {
            var classrooms = await _repository.GetAllAsync();

            if (!classrooms.Any()) return Result.Failure(classrooms, "classroom.empty", "there is no classroom registred");

            return Result.Success(classrooms);
        }

        public async Task<Result<ClassroomEntity>> GetByIdAsync(int id)
        {
            ClassroomEntity classroom = await _repository.GetByIdAsync(id);

            if (classroom is null) return Result.Failure(classroom, "classroom.notFound", "classroom not found")!;

            return Result.Success(classroom);
        }

        public async Task<Result> UpdateAsync(ClassroomEntity entity)
        {
            if (entity is null) return Result.Failure("classroom.Null", "classroom can't be null");

            var result = await _repository.UpdateAsync(entity);

            if (result <= 0) return Result.Failure("classroom.Failure", "entity not updated");

            return Result.Success();
        }
    }
}
