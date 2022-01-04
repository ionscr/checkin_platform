using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IUserScheduleRepository
    {
        IEnumerable<UserSchedule> GetUserSchedules();
        void AddUserSchedule(UserSchedule userSchedule);
        UserSchedule GetUserScheduleById(int id);
        UserSchedule GetUserScheduleByProps(int userId, int scheduleId);
        void DeleteUserSchedule(UserSchedule userSchedule);

    }
}
