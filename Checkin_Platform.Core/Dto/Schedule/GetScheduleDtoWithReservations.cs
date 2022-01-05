using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Dto.Schedule
{
    public class GetScheduleDtoWithReservations
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public GetClassroomDto Classroom { get; set; }
        public GetClassDto Class { get; set; }
        public IEnumerable<GetUserDto> Users { get; set; }
    }
}
