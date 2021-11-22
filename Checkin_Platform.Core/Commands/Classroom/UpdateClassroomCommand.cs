using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.Classroom
{
    public class UpdateClassroomCommand: IRequest<bool>
    {
        public GetClassroomDto classroomDto { get; set; }
    }
}
