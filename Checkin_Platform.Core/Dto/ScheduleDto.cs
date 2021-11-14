using Checkin_Platform.Domain;
using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Dto
{
    public class ScheduleDto
    {
        public DateTime DateTime { get; set; }
        public Classroom Classroom { get; set; }
        public Class Classn { get; set; }
        public List<ScheduleReservation> ScheduleReservations { get; set; }
    }
}
