using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _appDbContext.User.OrderBy(c => c.Id).ToList();
        }
        public IEnumerable<string> GetUsersRoles()
        {
            return _appDbContext.User.Select(r => r.Role).Distinct().ToList();
        }
        public IEnumerable<User> GetUsersByRole(string role)
        {
            return _appDbContext.User.Where(u => u.Role == role).ToList();
        }
        public IEnumerable<User> GetUsersBySchedule(int ScheduleId)
        {
            return _appDbContext.User.Include(u => u.UserSchedule).Where(u => u.UserSchedule.Any(us => us.ScheduleId == ScheduleId)).ToList();
        }
        public IEnumerable<User> GetOtherUsersBySchedule(int ScheduleId)
        {
            var query = (from u in _appDbContext.User
                         where u.Role == "Student"
                         from us in u.UserSchedule.DefaultIfEmpty()
                         where us.ScheduleId != ScheduleId
                         select new User { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, Role = u.Role, Year = u.Year, Group = u.Group }).ToList();
            return query;
        }
        public void AddUser(User user)
        {
            _appDbContext.User.Add(user);
        }
        public void DeleteUser(User user)
        {
            var userSchedules = _appDbContext.UserSchedule.Where(c => c.UserId == user.Id);
            foreach (var userSchedule in userSchedules)
            {
                _appDbContext.UserSchedule.Remove(userSchedule);
            }
            var userClasses = _appDbContext.Class.Where(c => c.UserId == user.Id);
            foreach (var userClass in userClasses)
            {
                var classSchedules = _appDbContext.Schedule.Where(s => s.ClassId == userClass.Id);
                foreach (var classSchedule in classSchedules)
                {
                    var userSchedulesBySchedule = _appDbContext.UserSchedule.Where(c => c.ScheduleId == classSchedule.Id);
                    foreach (var userSchedule in userSchedulesBySchedule)
                    {
                        _appDbContext.UserSchedule.Remove(userSchedule);
                    }
                    _appDbContext.Schedule.Remove(classSchedule);
                }
                _appDbContext.Class.Remove(userClass);
            }
            _appDbContext.User.Remove(user);
        }
        public User GetUserById(int id)
        {
            return _appDbContext.User.FirstOrDefault(c => c.Id == id);
        }
        public User UpdateUser(User user)
        {
            User updatedUser = _appDbContext.User.FirstOrDefault(c => c.Id == user.Id);
            updatedUser = user;
            return updatedUser;
        }
    }
}
