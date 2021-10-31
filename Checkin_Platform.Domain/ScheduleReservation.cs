using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Domain
{
    public class ScheduleReservation
    {
        public int Id { get; set; }
        public Schedule Schedule { get; set; }
        public User Student { get; set; }
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
    }
}
