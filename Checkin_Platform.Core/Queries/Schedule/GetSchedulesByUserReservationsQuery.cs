using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Queries.Schedule
{
    public class GetSchedulesByUserReservationsQuery : IRequest<IEnumerable<GetScheduleDto>>
    {
        public int UserId { get; set; }
    }
}
