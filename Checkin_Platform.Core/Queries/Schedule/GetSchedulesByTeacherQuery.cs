using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Queries.Schedule
{
    public class GetSchedulesByTeacherQuery : IRequest<IEnumerable<GetScheduleDto>>
    {
        public int TeacherId { get; set; }
    }
}
