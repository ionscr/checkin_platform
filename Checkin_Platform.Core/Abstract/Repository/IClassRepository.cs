using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IClassRepository
    {
        IQueryable<Class> GetClasses();
        void AddClass(Class classToAdd);
        Class GetClassById(int id);
        void DeleteClass(Class classToDelete);
    }
}
