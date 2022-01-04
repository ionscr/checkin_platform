using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.User
{
    public class GetUsersByScheduleQuery : IRequest<IEnumerable<GetUserDto>>
    {
        public int ScheduleId { get; set; }
    }
}
