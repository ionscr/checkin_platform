using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class UserScheduleRepository : IUserScheduleRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserScheduleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<UserSchedule> GetUserSchedules()
        {
            return _appDbContext.UserSchedule.Include(us => us.Schedule).Include(us => us.User).OrderBy(c => c.Id).ToList();
        }
        public void AddUserSchedule(UserSchedule userSchedule)
        {
            _appDbContext.UserSchedule.Add(userSchedule);
        }
        public void DeleteUserSchedule(UserSchedule userSchedule)
        {
            _appDbContext.UserSchedule.Remove(userSchedule);
        }
        public UserSchedule GetUserScheduleById(int id)
        {
            return _appDbContext.UserSchedule.FirstOrDefault(c => c.Id == id);
        }
    }
}
