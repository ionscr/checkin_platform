using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IScheduleRepository
    {
        IQueryable<Schedule> GetSchedules();
        void AddSchedule(Schedule schedule);
        Schedule GetScheduleById(int id);
        void DeleteSchedule(Schedule schedule);
    }
}
