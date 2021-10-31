using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Commands.ScheduleReservation
{
    public class CreateScheduleReservationCommand: IRequest<bool>
    {
        public ScheduleReservationDto ScheduleReservationDto { get; set; }
    }
}
