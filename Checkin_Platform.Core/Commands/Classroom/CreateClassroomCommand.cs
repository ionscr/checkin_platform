using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.Classroom
{
    public class CreateClassroomCommand: IRequest<bool>
    {
        public SetClassroomDto ClassroomDto { get; set; }
    }
}
