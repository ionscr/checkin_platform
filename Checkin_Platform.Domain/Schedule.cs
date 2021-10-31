using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Domain
{
    public class Schedule
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public Classroom Classroom { get; set; }
        public Class Classn { get; set; }
        public List<User> Reservations { get; set; }
    }
}
