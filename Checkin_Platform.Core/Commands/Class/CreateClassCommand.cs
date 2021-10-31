using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Commands.Class
{
    public class CreateClassCommand: IRequest<bool>
    {
        public ClassDto ClassDto { get; set; }
    }
}
