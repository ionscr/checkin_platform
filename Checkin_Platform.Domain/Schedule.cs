using System;
using System.Collections.Generic;

namespace Checkin_Platform.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Classroom Classroom { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public int ClassroomId { get; set; }
        public List<ScheduleReservation> ScheduleReservations { get; set; }
    }
}
