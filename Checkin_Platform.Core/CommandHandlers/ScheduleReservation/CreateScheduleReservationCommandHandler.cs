using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.ScheduleReservation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.ScheduleReservation
{
    public class CreateScheduleReservationCommandHandler: IRequest<bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateScheduleReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateScheduleReservationCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ScheduleReservation.Add(new Domain.ScheduleReservation
            {
                Schedule = request.ScheduleReservationDto.Schedule,
                Student = request.ScheduleReservationDto.Student
            });
            return true;
        }
    }
}
