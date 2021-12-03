using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.User
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public GetUserDto UserDto { get; set; }
    }
}
