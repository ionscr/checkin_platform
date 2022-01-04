using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Class;
using Checkin_Platform.Core.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteClassCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ClassRepository.GetClassById(request.Id);

            if(item == null)
            {
                throw new EntityNotFoundException("Class", request.Id);
            }
            _unitOfWork.ClassRepository.DeleteClass(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
