using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.ClassroomFeature;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.ClassroomFeature
{
    public class CreateClassroomFeatureCommandHandler: IRequest<bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateClassroomFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateClassroomFeatureCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ClassroomFeature.Add(new Domain.ClassroomFeature
            {
                Classroom = request.ClassroomFeatureDto.Classroom,
                Feature = request.ClassroomFeatureDto.Feature,
                ClassroomId = request.ClassroomFeatureDto.ClassroomId,
                FeatureId = request.ClassroomFeatureDto.FeatureId
            });
            return true;
        }
    }
}
