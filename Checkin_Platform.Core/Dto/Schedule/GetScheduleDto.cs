using System;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class GetScheduleDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public GetClassroomDto Classroom { get; set; }
        public GetClassDto Class { get; set; }
    }
}
