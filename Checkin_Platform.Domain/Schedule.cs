using System;
using System.Collections.Generic;

namespace Checkin_Platform.Domain
{
    public class Schedule
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public Classroom Classroom { get; set; }
        public Class Classn { get; set; }
        public List<ScheduleReservation> ScheduleReservations { get; set; }
    }
}
