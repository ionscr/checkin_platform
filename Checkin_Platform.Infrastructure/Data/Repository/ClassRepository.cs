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
        public void AddClass(Class classToAdd)
        {
            _appDbContext.Class.Add(classToAdd);
        }
        public void DeleteClass(Class classToDelete)
        {
            _appDbContext.Class.Remove(classToDelete);
        }
        public Class GetClassById(int id)
        {
            return _appDbContext.Class.FirstOrDefault(c => c.Id == id);
        }
        public Class UpdateClass(Class Class)
        {
            Class updatedClass = _appDbContext.Class.FirstOrDefault(c => c.Id == Class.Id);
            updatedClass = Class;
            return updatedClass;
        }
    }
}
