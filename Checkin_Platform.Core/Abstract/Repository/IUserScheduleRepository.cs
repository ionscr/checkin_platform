using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IUserScheduleRepository
    {
        IQueryable<UserSchedule> GetUserSchedules();
        void AddUserSchedule(UserSchedule userSchedule);
    }
}
