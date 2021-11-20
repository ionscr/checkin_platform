using MediatR;

namespace Checkin_Platform.Core.Commands.Classroom
{
    public class DeleteClassroomCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
