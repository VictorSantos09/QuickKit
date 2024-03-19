using Classroom.Core.Entities;
using Classroom.Core.Repositories;
using QuickKit.Shared.Services;

namespace Classroom.Core.Services
{
    public interface IClassroomService : IService<ClassroomEntity, int>
    {

    }

    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task AddAsync(ClassroomEntity entity)
        {
            // ... business rules
            await _classroomRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            // ... business rules
            await _classroomRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<ClassroomEntity>> GetAllAsync()
        {
            // ... business rules
            return _classroomRepository.GetAllAsync();
        }

        public async Task<ClassroomEntity> GetByIdAsync(int id)
        {
            // ... business rules
            return await _classroomRepository.GetByIdThrowAsync(id, $"classroom id {id} was not found");
        }

        public async Task UpdateAsync(ClassroomEntity entity)
        {
            // ... business rules
            await _classroomRepository.UpdateAsync(entity);
        }
    }
}
