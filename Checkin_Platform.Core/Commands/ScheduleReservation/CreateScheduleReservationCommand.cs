using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.ScheduleReservation
{
    public class CreateScheduleReservationCommand: IRequest<bool>
    {
        public ScheduleReservationDto ScheduleReservationDto { get; set; }
    }
}
