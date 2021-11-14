using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Infrastructure.Data
{
    public class AppDbContext : IUnitOfWork
    {
        public IList<User> User { get; set; } = new List<User>();
        public IList<Class> Class { get; set; } = new List<Class>();
        public IList<Classroom> Classroom { get; set; } = new List<Classroom>();
        public IList<Feature> Feature { get; set; } = new List<Feature>();
        public IList<Schedule> Schedule { get; set; } = new List<Schedule>();
        public IList<ClassroomFeature> ClassroomFeature { get; set; } = new List<ClassroomFeature>();
        public IList<ScheduleReservation> ScheduleReservation { get; set; } = new List<ScheduleReservation>();
        
    }
}
