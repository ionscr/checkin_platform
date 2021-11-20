using MediatR;

namespace Checkin_Platform.Core.Commands.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
