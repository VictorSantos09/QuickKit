using Classroom.Core.Entities;
using Classroom.Core.Repositories;
using QuickKit.ResultTypes;
using QuickKit.Shared.Extensions;

namespace Classroom.Core.Services;

public class ClassroomService : IClassroomService
{
    private readonly IClassroomRepository _repository;

    public ClassroomService(IClassroomRepository repository)
    {
        _repository = repository;
    }

    public async Task<Final> AddAsync(ClassroomEntity entity)
    {
        if (entity.IsNull()) return Final.Failure("classroom.Null", "classroom can't be null");

        int result = await _repository.AddAsync(entity);

        return result <= 0 ? Final.Failure("classroom.Failure", "entity not saved") : Final.Success();
    }

    public async Task<Final> DeleteAsync(int id)
    {
        if (id <= 0) return Final.Failure("classroom.invalidId", "id not valid");

        int result = await _repository.DeleteAsync(id);

        return result > 0 ? Final.Success() : Final.Failure("classroom.deleteFail", "delete fail");
    }

    public async Task<Final<IEnumerable<ClassroomEntity>>> GetAllAsync()
    {
        IEnumerable<ClassroomEntity> classrooms = await _repository.GetAllAsync();

        return !classrooms.Any()
            ? Final.Failure(classrooms, "classroom.empty", "there is no classroom registred")
            : Final.Success(classrooms);
    }

    public async Task<Final<ClassroomEntity>> GetByIdAsync(int id)
    {
        ClassroomEntity? classroom = await _repository.GetByIdAsync(id);

        return classroom is null ? Final.Failure(classroom, "classroom.notFound", "classroom not found") : Final.Success(classroom);
    }

    public async Task<Final> UpdateAsync(ClassroomEntity entity)
    {
        if (entity is null) return Final.Failure("classroom.Null", "classroom can't be null");

        int result = await _repository.UpdateAsync(entity);

        return result <= 0 ? Final.Failure("classroom.Failure", "entity not updated") : Final.Success();
    }
}
