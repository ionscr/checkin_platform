using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.User
{
    public class CreateUserCommand: IRequest<bool>
    {
        public UserDto UserDto { get; set; }
    }
}
