using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassroomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Classroom> GetClassrooms()
        {
            return _appDbContext.Classroom.OrderBy(c => c.Id);
        }
        public void AddClassroom(Classroom classroom)
        {
            _appDbContext.Classroom.Add(classroom);
        }
    }
}
