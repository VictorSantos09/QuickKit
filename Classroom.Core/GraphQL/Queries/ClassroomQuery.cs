using Classroom.Core.Entities;
using Classroom.Core.GraphQL.Queries.Base;
using Classroom.Core.Repositories;

namespace Classroom.Core.GraphQL.Queries;

[ExtendObjectType(typeof(Query))]
public class ClassroomQuery
{
    private readonly IClassroomRepository _repository;

    public ClassroomQuery(IClassroomRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClassroomEntity?> GetClassromById(int id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<ClassroomEntity>> GetAllClassrooms(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    //[UsePaging(IncludeTotalCount = true, MaxPageSize = 20)]
    //[UseFiltering]
    //[UseSorting]
    //public async Task<IEnumerable<ClassroomEntity>> GetPaginedClassrooms()
    //{
    //    return await _repository.GetAllPagedAsync();
    //}
}