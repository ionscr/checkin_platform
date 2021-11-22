using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.Schedule
{
    public class UpdateScheduleCommand : IRequest<bool>
    {
        public GetScheduleDto scheduleDto { get; set; }
    }
}
