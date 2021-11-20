using System;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class GetScheduleDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Classroom Classroom { get; set; }
        public Class Class { get; set; }
    }
}
