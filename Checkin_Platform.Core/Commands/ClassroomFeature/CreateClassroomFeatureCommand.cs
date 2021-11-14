using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.ClassroomFeature
{
    public class CreateClassroomFeatureCommand: IRequest<bool>
    {
        public ClassroomFeatureDto ClassroomFeatureDto { get; set; }
    }
}
