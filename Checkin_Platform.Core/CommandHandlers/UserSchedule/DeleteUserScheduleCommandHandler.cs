using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.UserSchedule;
using Checkin_Platform.Core.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.UserSchedule
{
    public class DeleteUserScheduleCommandHandler : IRequestHandler<DeleteUserScheduleCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteUserScheduleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserScheduleCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.UserScheduleRepository.GetUserScheduleById(request.Id);

            if (item == null)
            {
                throw new EntityNotFoundException("UserSchedule", request.Id);
            }
            _unitOfWork.UserScheduleRepository.DeleteUserSchedule(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
