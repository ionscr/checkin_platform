using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Commands.User
{
    public class CreateUserCommand: IRequest<bool>
    {
        public UserDto UserDto { get; set; }
    }
}
