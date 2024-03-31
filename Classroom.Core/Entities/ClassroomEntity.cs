using QuickKit.Shared.Entities;

namespace Classroom.Core.Entities;

/// <summary>
/// Define a class
/// </summary>
public class ClassroomSnapshot
{
    /// <summary>
    /// Define a ID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Define the name
    /// </summary>
    public string CLASSROOM_NAME { get; set; }

    /// <summary>
    /// Use this
    /// </summary>
    /// <param name="iD"></param>
    /// <param name="cLASSROOM_NAME"></param>
    public ClassroomSnapshot(int iD, string cLASSROOM_NAME)
    {
        ID = iD;
        CLASSROOM_NAME = cLASSROOM_NAME;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ClassroomSnapshot()
    {

    }
}

/// <summary>
/// Main Entity
/// </summary>
public class ClassroomEntity : IEntity<ClassroomEntity, ClassroomSnapshot, int>
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Define the name
    /// </summary>
    public string ClassroomName { get; set; }

    /// <summary>
    /// Use this
    /// </summary>
    /// <param name="name"></param>
    public ClassroomEntity(string name)
    {
        ClassroomName = name;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ClassroomEntity()
    {

    }

    /// <summary>
    /// Convert from <see cref="ClassroomSnapshot"/>
    /// </summary>
    /// <param name="snapshot"></param>
    /// <returns>The converted entity</returns>
    public static ClassroomEntity? FromSnapshot(ClassroomSnapshot snapshot)
    {
        return snapshot is null
            ? null
            : new()
            {
                Id = snapshot.ID,
                ClassroomName = snapshot.CLASSROOM_NAME
            };
    }

    /// <summary>
    /// Convert to <see cref="ClassroomSnapshot"/>
    /// </summary>
    /// <returns>The converted snapshot</returns>
    public ClassroomSnapshot ToSnapshot()
    {
        return new(Id, ClassroomName);
    }
}
