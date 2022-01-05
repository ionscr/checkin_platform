using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetClasses();
        IEnumerable<Class> GetClassesByTeacher(int teacherId);
        void AddClass(Class classToAdd);
        Class GetClassById(int id);
        Class UpdateClass(Class Class);
        void DeleteClass(Class classToDelete);
    }
}
