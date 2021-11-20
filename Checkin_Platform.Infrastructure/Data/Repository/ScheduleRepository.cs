using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _appDbContext;

        public ScheduleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Schedule> GetSchedules()
        {
            return _appDbContext.Schedule.OrderBy(c => c.Id);
        }
        public void AddSchedule(Schedule schedule)
        {
            _appDbContext.Schedule.Add(schedule);
        }
        public void DeleteSchedule(Schedule schedule)
        {
            _appDbContext.Schedule.Remove(schedule);
        }
        public Schedule GetScheduleById(int id)
        {
            return _appDbContext.Schedule.FirstOrDefault(c => c.Id == id);
        }
    }
}
