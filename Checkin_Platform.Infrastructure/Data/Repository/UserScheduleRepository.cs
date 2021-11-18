using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
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
        public IQueryable<UserSchedule> GetUserSchedules()
        {
            return _appDbContext.UserSchedule.OrderBy(c => c.Id);
        }
        public void AddUserSchedule(UserSchedule userSchedule)
        {
            _appDbContext.UserSchedule.Add(userSchedule);
        }
    }
}
