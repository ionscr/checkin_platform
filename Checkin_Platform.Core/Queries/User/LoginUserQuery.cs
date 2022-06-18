using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Dto.User;
using MediatR;

namespace Checkin_Platform.Core.Queries.User
{
    public class LoginUserQuery : IRequest<GetUserDto>
    {
        public LoginUserDto UserDto { get; set; }
    }
}
