using MediatR;

namespace Checkin_Platform.Core.Commands.UserSchedule
{
    public class DeleteUserScheduleCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
