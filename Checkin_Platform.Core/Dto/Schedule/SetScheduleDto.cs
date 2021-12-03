using System;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class SetScheduleDto
    {
        public DateTime DateTime { get; set; }
        public int ClassroomId { get; set; }
        public int ClassId { get; set; }
    }
}
