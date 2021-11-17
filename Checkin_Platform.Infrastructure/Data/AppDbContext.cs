using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;

namespace Checkin_Platform.Infrastructure.Data
{
    public class AppDbContext : DbContext ,IUnitOfWork
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
        public DbSet<ScheduleReservation> ScheduleReservation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=CheckinPlatform;Trusted_Connection=True;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ScheduleReservation>()
                .HasOne(t => t.Schedule)
                .WithMany(t => t.ScheduleReservations)
                .HasForeignKey(t => t.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ScheduleReservation>()
                .HasOne(t => t.User)
                .WithMany(t => t.ScheduleReservations)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
