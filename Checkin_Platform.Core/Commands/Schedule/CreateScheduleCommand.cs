using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.Schedule
{
    public class CreateScheduleCommand: IRequest<bool>
    {
        public SetScheduleDto ScheduleDto { get; set; }
    }
}
