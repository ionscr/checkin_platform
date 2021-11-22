using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Schedule;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Schedule
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateScheduleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ScheduleRepository.GetScheduleById(request.scheduleDto.Id);
            item.DateTime = request.scheduleDto.DateTime;
            item.Class = request.scheduleDto.Class;
            item.Classroom = request.scheduleDto.Classroom;
            _unitOfWork.ScheduleRepository.UpdateSchedule(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
