using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using System;
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
        public IQueryable<Schedule> GetSchedulesByDate(DateTime dateTime)
        {
            return _appDbContext.Schedule.Where(s => s.DateTime.Date == dateTime.Date).OrderBy(s => s.DateTime);
        }
        public IQueryable<Schedule> GetSchedulesByTeacher(int teacherId)
        {
            return _appDbContext.Schedule.Where(s => s.Class.Teacher.Id == teacherId);
        }
        public IQueryable<Schedule> GetSchedulesByUserReservations(int userId)
        {
            return _appDbContext.Schedule.Include(s => s.UserSchedule).Where(s => s.UserSchedule.All(us => us.User.Id == userId));
        }
        public Schedule UpdateSchedule(Schedule schedule)
        {
            Schedule updatedSchedule = _appDbContext.Schedule.FirstOrDefault(c => c.Id == schedule.Id);
            updatedSchedule = schedule;
            return updatedSchedule;
        }
    }
}
