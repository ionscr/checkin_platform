using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Classroom;
using Checkin_Platform.Core.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Classroom
{
    public class DeleteClassroomCommandHandler : IRequestHandler<DeleteClassroomCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteClassroomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ClassroomRepository.GetClassroomById(request.Id);

            if (item == null)
            {
                throw new EntityNotFoundException("Classroom", request.Id);
            }
            _unitOfWork.ClassroomRepository.DeleteClassroom(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
