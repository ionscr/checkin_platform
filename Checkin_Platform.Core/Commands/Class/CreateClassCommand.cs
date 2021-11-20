using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.Class
{
    public class CreateClassCommand: IRequest<bool>
    {
        public SetClassDto ClassDto { get; set; }
    }
}
