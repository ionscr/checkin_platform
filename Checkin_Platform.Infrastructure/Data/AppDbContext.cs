using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Domain;
using Checkin_Platform.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Checkin_Platform.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions){}
        public DbSet<User> User { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ClassroomFeature> ClassroomFeature { get; set; } 
        public DbSet<UserSchedule> UserSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserScheduleConfiguration());
        }
    }
}
