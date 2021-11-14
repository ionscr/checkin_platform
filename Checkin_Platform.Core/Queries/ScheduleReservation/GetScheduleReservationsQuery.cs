using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.ScheduleReservation
{
    public class GetScheduleReservationsQuery : IRequest<IEnumerable<ScheduleReservationDto>>
    {
    }
}
