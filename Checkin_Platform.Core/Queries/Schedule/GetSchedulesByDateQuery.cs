using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.Schedule
{
    public class GetSchedulesByDateQuery: IRequest<IEnumerable<ScheduleDto>>
    {
        public DateTime DateTime { get; set; }
    }
}
