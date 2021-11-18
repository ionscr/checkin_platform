using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.UserSchedule
{
    public class GetUserSchedulesQuery : IRequest<IEnumerable<UserScheduleDto>>
    {
    }
}
