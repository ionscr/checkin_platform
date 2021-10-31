using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Commands.Classroom
{
    public class CreateClassroomCommand: IRequest<bool>
    {
        public ClassroomDto ClassroomDto { get; set; }
    }
}
