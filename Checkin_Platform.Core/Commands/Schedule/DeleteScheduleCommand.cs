using MediatR;

namespace Checkin_Platform.Core.Commands.Schedule
{
    public class DeleteScheduleCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
