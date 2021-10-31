using Checkin_Platform.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Dto
{
    public class ScheduleDto
    {
        public DateTime DateTime { get; set; }
        public Classroom Classroom { get; set; }
        public Class classn { get; set; }
        public List<User> Reservations { get; set; }
    }
}
