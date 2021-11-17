using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Schedule;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Schedule
{
    public class CreateScheduleCommandHandler: IRequest<bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateScheduleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.Schedule.Add(new Domain.Schedule
            {
                DateTime = request.ScheduleDto.DateTime,
                Classroom = request.ScheduleDto.Classroom,
                Class = request.ScheduleDto.Classn
                
            });
            return true;
        }
    }
}
