using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;

namespace Checkin_Platform.Core.Abstract
{
    public interface IUnitOfWork
    {
        public DbSet<User> User { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<ClassroomFeature> ClassroomFeature { get; set; }
        public DbSet<ScheduleReservation> ScheduleReservation { get; set; }

    }
}
