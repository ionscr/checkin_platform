using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Dto.Schedule
{
    public class GetGroupScheduleDtoUnfixed
    {
        public DateTime Date { get; set; }
        public List<Domain.Schedule> Schedules { get; set; }
    }
}
