using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public IEnumerable<Class> GetClasses()
        {
            return _appDbContext.Class.Include(c => c.Teacher).OrderBy(c => c.Id).ToList();
        }
        public IEnumerable<Class> GetClassesByTeacher(int teacherId)
        {
            return _appDbContext.Class.Include(c => c.Teacher).Where(c => c.Teacher.Id == teacherId).OrderBy(c => c.Id).ToList();
        }
        public void AddClass(Class classToAdd)
        {
            _appDbContext.Class.Add(classToAdd);
        }
        public void DeleteClass(Class classToDelete)
        {
            var classSchedules = _appDbContext.Schedule.Where(s => s.ClassId == classToDelete.Id);
            foreach (var classSchedule in classSchedules)
            {
                var userSchedules = _appDbContext.UserSchedule.Where(c => c.ScheduleId == classSchedule.Id);
                foreach (var userSchedule in userSchedules)
                {
                    _appDbContext.UserSchedule.Remove(userSchedule);
                }
                _appDbContext.Schedule.Remove(classSchedule);
            }
            _appDbContext.Class.Remove(classToDelete);
        }
        public Class GetClassById(int id)
        {
            return _appDbContext.Class.Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
        }
        public Class UpdateClass(Class Class)
        {
            Class updatedClass = _appDbContext.Class.FirstOrDefault(c => c.Id == Class.Id);
            updatedClass = Class;
            return updatedClass;
        }
    }
}
