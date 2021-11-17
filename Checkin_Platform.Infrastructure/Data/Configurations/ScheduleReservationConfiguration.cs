using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Checkin_Platform.Infrastructure.Data.Configurations
{
    public class ScheduleReservationConfiguration : IEntityTypeConfiguration<ScheduleReservation>
    {
        public void Configure(EntityTypeBuilder<ScheduleReservation> builder)
        {
            builder
            .HasOne(t => t.Schedule) 
            .WithMany(t => t.ScheduleReservations)
            .HasForeignKey(t => t.ScheduleId)  
            .OnDelete(DeleteBehavior.Restrict);
            
            builder
            .HasOne(t => t.User)
            .WithMany(t => t.ScheduleReservations)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
