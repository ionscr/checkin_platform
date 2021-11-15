using System;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class ScheduleDto
    {
        public DateTime DateTime { get; set; }
        public Classroom Classroom { get; set; }
        public Class Classn { get; set; }
    }
}
