using MediatR;

namespace Checkin_Platform.Core.Commands.UserSchedule
{
    public class DeleteUserScheduleCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int ScheduleId { get; set; }
    }
}
