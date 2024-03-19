using QuickKit.Shared.Entities;

namespace Classroom.Core.Entities
{
    public class ClassroomSnapshot
    {
        public int ID { get; set; }
        public string CLASSROOM_NAME { get; set; }

        public ClassroomSnapshot(int iD, string cLASSROOM_NAME)
        {
            ID = iD;
            CLASSROOM_NAME = cLASSROOM_NAME;
        }

        public ClassroomSnapshot()
        {
                
        }
    }

    public class ClassroomEntity : IEntity<ClassroomEntity, ClassroomSnapshot, int>
    {
        public int Id { get; set; }
        public string ClassroomName { get; set; }

        public ClassroomEntity(string name)
        {
            ClassroomName = name;
        }

        public ClassroomEntity()
        {
                
        }

        public static ClassroomEntity FromSnapshot(ClassroomSnapshot snapshot)
        {
            if (snapshot is null) return null;

            return new()
            {
                Id = snapshot.ID,
                ClassroomName = snapshot.CLASSROOM_NAME
            };
        }

        public ClassroomSnapshot ToSnapshot()
        {
            return new(Id, ClassroomName);
        }
    }
}
