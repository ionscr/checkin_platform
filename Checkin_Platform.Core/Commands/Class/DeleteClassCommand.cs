using MediatR;

namespace Checkin_Platform.Core.Commands.Class
{
    public class DeleteClassCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
