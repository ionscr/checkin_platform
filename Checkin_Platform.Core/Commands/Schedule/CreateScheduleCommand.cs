using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Commands.Schedule
{
    public class CreateScheduleCommand: IRequest<bool>
    {
        public ScheduleDto ScheduleDto { get; set; }
    }
}
