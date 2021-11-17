using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Infrastructure.Data.Configurations
{
    public class ScheduleReservationConfiguration : IEntityTypeConfiguration<ScheduleReservation>
    {
        public void Configure(EntityTypeBuilder<ScheduleReservation> builder)
        {
            //builder.Entity<Schedule>()
        }
    }
}
