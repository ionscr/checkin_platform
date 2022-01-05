using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Dto.Schedule
{
    public class GetGroupScheduleDto
    {
        public DateTime Date { get; set; }
        public List<GetScheduleDtoWithReservations> Schedules { get; set; }
    }
}
