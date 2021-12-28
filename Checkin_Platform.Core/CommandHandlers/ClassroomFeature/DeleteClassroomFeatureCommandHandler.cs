using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.ClassroomFeature;
using Checkin_Platform.Core.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.ClassroomFeature
{
    public class DeleteClassroomFeatureCommandHandler: IRequestHandler<DeleteClassroomFeatureCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteClassroomFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClassroomFeatureCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ClassroomFeatureRepository.GetClassroomFeatureByProps(request.FeatureId, request.ClassroomId);

            if (item == null)
            {
                throw new EntityNotFoundException("ClassroomFeature", request.FeatureId);
            }
            _unitOfWork.ClassroomFeatureRepository.DeleteClassroomFeature(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
