using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IUserScheduleRepository
    {
        IEnumerable<UserSchedule> GetUserSchedules();
        void AddUserSchedule(UserSchedule userSchedule);
        UserSchedule GetUserScheduleById(int id);
        void DeleteUserSchedule(UserSchedule userSchedule);

    }
}
