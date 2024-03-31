using Classroom.Core.Entities;
using Classroom.Core.GraphQL.Queries.Base;
using Classroom.Core.Repositories;

namespace Classroom.Core.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class TeacherQuery
{
    private readonly IClassroomRepository _repository;

    public TeacherQuery(IClassroomRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClassroomEntity?> GetTeacherById(int id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<ClassroomEntity>> GetAllTeachers(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}
