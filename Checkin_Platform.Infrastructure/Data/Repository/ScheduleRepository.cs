using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Schedule> GetSchedules()
        {
            return _appDbContext.Schedule.Include(s => s.Class).ThenInclude(s=> s.Teacher).Include(s => s.Classroom).OrderBy(c => c.Id).ToList();
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
        public IEnumerable<Schedule> GetSchedulesByDate(DateTime dateTime)
        {
            return _appDbContext.Schedule.Include(s => s.Class).ThenInclude(s => s.Teacher).Include(s => s.Classroom).Where(s => s.DateTime.Date == dateTime.Date).OrderBy(s => s.DateTime).ToList();
        }
        public IEnumerable<Schedule> GetSchedulesByWeek(DateTime StartDate)
        {
            DateTime EndDate = StartDate.AddDays(5);
            return _appDbContext.Schedule.Include(s => s.Class).ThenInclude(s => s.Teacher).Include(s => s.Classroom).Where(s => s.DateTime.Date >= StartDate.Date && s.DateTime.Date <= EndDate.Date).OrderBy(s => s.DateTime).ToList();
        }
        public IEnumerable<Schedule> GetSchedulesByTeacher(int teacherId)
        {
            return _appDbContext.Schedule.Include(s => s.Class).ThenInclude(s => s.Teacher).Include(s => s.Classroom).Where(s => s.Class.Teacher.Id == teacherId).ToList();
        }
        public IEnumerable<Schedule> GetSchedulesByUserReservations(int userId)
        {
            return _appDbContext.Schedule.Include(s => s.Class).ThenInclude(s => s.Teacher).Include(s => s.Classroom).Include(s => s.UserSchedule).Where(s => s.UserSchedule.Any(us => us.User.Id == userId)).ToList();
        }
        public Schedule UpdateSchedule(Schedule schedule)
        {
            Schedule updatedSchedule = _appDbContext.Schedule.FirstOrDefault(c => c.Id == schedule.Id);
            updatedSchedule = schedule;
            return updatedSchedule;
        }
    }
}
