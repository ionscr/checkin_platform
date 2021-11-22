using MediatR;
using Checkin_Platform.Domain;
using Checkin_Platform.Core.Dto;

namespace Checkin_Platform.Core.Commands.Class
{
    public class UpdateClassCommand : IRequest<bool>
    {
        public GetClassDto ClassDto { get; set; }
    }
}
