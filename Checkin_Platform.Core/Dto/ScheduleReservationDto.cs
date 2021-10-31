using Checkin_Platform.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Dto
{
    public class ScheduleReservationDto
    {
        public Schedule Schedule { get; set; }
        public User Student { get; set; }
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
    }
}
