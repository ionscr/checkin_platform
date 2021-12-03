using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Feature;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Feature
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.FeatureRepository.GetFeatureById(request.FeatureDto.Id);
            item.Name = request.FeatureDto.Name;
            _unitOfWork.FeatureRepository.UpdateFeature(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
