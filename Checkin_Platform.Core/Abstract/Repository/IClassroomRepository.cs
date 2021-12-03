using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IClassroomRepository
    {
        IEnumerable<Classroom> GetClassrooms();
        void AddClassroom(Classroom classroom);
        Classroom GetClassroomById(int id);
        void DeleteClassroom(Classroom classroom);
        Classroom UpdateClassroom(Classroom classroom);
    }
}
