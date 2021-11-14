using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Feature;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Feature
{
    public class CreateFeatureCommandHandler: IRequest<bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.Feature.Add(new Domain.Feature
            {
                Nume = request.FeatureDto.Nume,
                ClassroomFeatures = request.FeatureDto.ClassroomFeatures
            });
            return true;
        }

    }
}
