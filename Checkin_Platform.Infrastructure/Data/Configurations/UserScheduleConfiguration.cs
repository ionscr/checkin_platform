using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Checkin_Platform.Infrastructure.Data.Configurations
{
    public class UserScheduleConfiguration : IEntityTypeConfiguration<UserSchedule>
    {
        public void Configure(EntityTypeBuilder<UserSchedule> builder)
        {
            builder
            .HasOne(t => t.Schedule) 
            .WithMany(t => t.UserSchedule)
            .HasForeignKey(t => t.ScheduleId)  
            .OnDelete(DeleteBehavior.Restrict);
            
            builder
            .HasOne(t => t.User)
            .WithMany(t => t.UserSchedule)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
