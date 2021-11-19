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
        public void UpdateClass(Class class_to_update)
        {
            var selectedClass = _appDbContext.Class.Find(class_to_update.Id);
            selectedClass.Name = class_to_update.Name;
            selectedClass.Schedules = class_to_update.Schedules;
            selectedClass.Section = class_to_update.Section;
            selectedClass.Teacher = class_to_update.Teacher;
            selectedClass.Year = class_to_update.Year;
        }
    }
}
