using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.Schedule
{
    public class GetSchedulesQuery : IRequest<IEnumerable<GetScheduleDto>>
    {
    }
}
