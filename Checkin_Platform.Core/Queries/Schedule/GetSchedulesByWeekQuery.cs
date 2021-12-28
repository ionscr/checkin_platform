using Checkin_Platform.Core.Dto.Schedule;
using MediatR;
using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.Schedule
{
    public class GetSchedulesByWeekQuery : IRequest<IEnumerable<GetGroupScheduleDto>>
    {
        public DateTime StartDate { get; set; }
    }
}
