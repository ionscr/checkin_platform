using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Schedule;
using Checkin_Platform.Core.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Schedule
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteScheduleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ScheduleRepository.GetScheduleById(request.Id);

            if (item == null)
            {
                throw new EntityNotFoundException("Schedule", request.Id);
            }
            var userSchedules = _unitOfWork.UserScheduleRepository.GetUserSchedules().Where(c => c.ScheduleId == request.Id);
            foreach (var userSchedule in userSchedules)
            {
                _unitOfWork.UserScheduleRepository.DeleteUserSchedule(userSchedule);
            }
            _unitOfWork.ScheduleRepository.DeleteSchedule(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
