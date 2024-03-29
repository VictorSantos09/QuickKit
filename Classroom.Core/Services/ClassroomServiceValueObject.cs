using Classroom.Core.Entities;
using Classroom.Core.Repositories;
using Classroom.Core.Services.Common;
using QuickKit.ResultTypes;
using QuickKit.Shared.Extensions;

namespace Classroom.Core.Services
{
    public interface IClassroomServiceValueObject : IDomainSelfContainedValueObjectService<ClassroomEntity, int> { }

    public class ClassroomServiceValueObject : IClassroomServiceValueObject
    {
        private readonly IClassroomRepository _repository;

        public ClassroomServiceValueObject(IClassroomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Final> AddAsync(ClassroomEntity entity)
        {
            if (entity.IsNull()) return Final.Failure("classroom.Null", "classroom can't be null");

            var result = await _repository.AddAsync(entity);

            if (result <= 0) return Final.Failure("classroom.Failure", "entity not saved");

            return Final.Success();
        }

        public async Task<Final> DeleteAsync(int id)
        {
            if (id <= 0) return Final.Failure("classroom.invalidId", "id not valid");

            var result = await _repository.DeleteAsync(id);

            if (result > 0) return Final.Success();
            return Final.Failure("classroom.deleteFail", "delete fail");
        }

        public async Task<Final<IEnumerable<ClassroomEntity>>> GetAllAsync()
        {
            var classrooms = await _repository.GetAllAsync();

            if (!classrooms.Any()) return Final.Failure(classrooms, "classroom.empty", "there is no classroom registred");

            return Final.Success(classrooms);
        }

        public async Task<Final<ClassroomEntity>> GetByIdAsync(int id)
        {
            ClassroomEntity classroom = await _repository.GetByIdAsync(id);

            if (classroom is null) return Final.Failure(classroom, "classroom.notFound", "classroom not found")!;

            return Final.Success(classroom);
        }

        public async Task<Final> UpdateAsync(ClassroomEntity entity)
        {
            if (entity is null) return Final.Failure("classroom.Null", "classroom can't be null");

            var result = await _repository.UpdateAsync(entity);

            if (result <= 0) return Final.Failure("classroom.Failure", "entity not updated");

            return Final.Success();
        }
    }
}
