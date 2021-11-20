using MediatR;

namespace Checkin_Platform.Core.Commands.Feature
{
    public class DeleteFeatureCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
