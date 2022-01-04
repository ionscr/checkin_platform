using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Feature;
using Checkin_Platform.Core.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Feature
{
    public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.FeatureRepository.GetFeatureById(request.Id);

            if (item == null)
            {
                throw new EntityNotFoundException("Feature", request.Id);
            }
            _unitOfWork.FeatureRepository.DeleteFeature(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
