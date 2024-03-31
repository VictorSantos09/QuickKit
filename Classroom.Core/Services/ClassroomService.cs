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

    public async Task<IFinal> AddAsync(ClassroomEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity.IsNull()) return Final.Failure("classroom.Null", "classroom can't be null");

        int result = await _repository.AddAsync(entity, cancellationToken);

        return result <= 0 ? Final.Failure("classroom.Failure", "entity not saved") : Final.Success();
    }

    public async Task<IFinal> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0) return Final.Failure("classroom.invalidId", "id not valid");

        int result = await _repository.DeleteAsync(id, cancellationToken);

        return result > 0 ? Final.Success() : Final.Failure("classroom.deleteFail", "delete fail");
    }

    public async Task<IFinal<IEnumerable<ClassroomEntity>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<ClassroomEntity> classrooms = await _repository.GetAllAsync(cancellationToken);

        return !classrooms.Any()
            ? Final.Failure(classrooms, "classroom.empty", "there is no classroom registred")
            : Final.Success(classrooms);
    }

    public async Task<IFinal<ClassroomEntity?>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        ClassroomEntity? classroom = await _repository.GetByIdAsync(id, cancellationToken);

        if (classroom.IsNull()) return Final.Failure(classroom, "classroom.notFound", "classroom not found");

        else return Final.Success(classroom);
    }

    public async Task<IFinal> UpdateAsync(ClassroomEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity is null) return Final.Failure("classroom.Null", "classroom can't be null");

        int result = await _repository.UpdateAsync(entity, cancellationToken);

        return result <= 0 ? Final.Failure("classroom.Failure", "entity not updated") : Final.Success();
    }
}
