using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.UserSchedule
{
    public class CreateUserScheduleCommand: IRequest<bool>
    {
        public UserScheduleDto UserScheduleDto { get; set; }
    }
}
