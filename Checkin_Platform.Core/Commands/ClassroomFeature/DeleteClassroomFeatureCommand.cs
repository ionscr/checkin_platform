using MediatR;

namespace Checkin_Platform.Core.Commands.ClassroomFeature
{
    public class DeleteClassroomFeatureCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
