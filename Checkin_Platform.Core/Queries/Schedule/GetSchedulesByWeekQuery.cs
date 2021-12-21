using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.Schedule
{
    public class GetSchedulesByWeekQuery : IRequest<IEnumerable<GetScheduleDto>>
    {
        public DateTime StartDate { get; set; }
    }
}
