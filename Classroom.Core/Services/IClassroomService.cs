using Classroom.Core.Entities;
using Classroom.Core.Services.Common;

namespace Classroom.Core.Services
{
    public interface IClassroomService : IDomainSelfContainedService<ClassroomEntity, int> { }
}
