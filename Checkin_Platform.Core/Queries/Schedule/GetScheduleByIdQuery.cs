using System.Collections.Generic;
using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Queries.Schedule
{
    public class GetScheduleByIdQuery : IRequest<ScheduleDto>
    {
        public int Id { get; set; }
    }
}
