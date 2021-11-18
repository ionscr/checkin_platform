using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IClassroomRepository
    {
        IQueryable<Classroom> GetClassrooms();
        void AddClassroom(Classroom classroom);
    }
}
