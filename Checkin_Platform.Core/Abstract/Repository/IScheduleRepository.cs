using Checkin_Platform.Domain;
using System;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IScheduleRepository
    {
        IQueryable<Schedule> GetSchedules();
        void AddSchedule(Schedule schedule);
        Schedule GetScheduleById(int id);
        void DeleteSchedule(Schedule schedule);
        IQueryable<Schedule> GetSchedulesByDate(DateTime dateTime);
        IQueryable<Schedule> GetSchedulesByTeacher(int teacherId);
        IQueryable<Schedule> GetSchedulesByUserReservations(int userId);

        Schedule UpdateSchedule(Schedule schedule);
    }
}
