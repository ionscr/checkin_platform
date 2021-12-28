using Checkin_Platform.Core.Dto.Schedule;
using Checkin_Platform.Domain;
using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> GetSchedules();
        void AddSchedule(Schedule schedule);
        Schedule GetScheduleById(int id);
        void DeleteSchedule(Schedule schedule);
        IEnumerable<Schedule> GetSchedulesByDate(DateTime dateTime);
        IEnumerable<Schedule> GetSchedulesByTeacher(int teacherId);
        IEnumerable<Schedule> GetSchedulesByUserReservations(int userId);
        Schedule UpdateSchedule(Schedule schedule);
        IEnumerable<GetGroupScheduleDtoUnfixed> GetSchedulesByWeek(DateTime StartDate);
    }
}
