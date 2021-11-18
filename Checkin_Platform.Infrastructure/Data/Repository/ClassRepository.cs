using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Class> GetClasses()
        {
            return _appDbContext.Class.OrderBy(c => c.Id);
        }
        public void AddClass(Class class_to_add)
        {
            _appDbContext.Class.Add(class_to_add);
        }
    }
}
