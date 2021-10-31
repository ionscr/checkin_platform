using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.ScheduleReservation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
                ScheduleId = request.ScheduleReservationDto.ScheduleId,
                Student = request.ScheduleReservationDto.Student,
                StudentId = request.ScheduleReservationDto.StudentId
            });
            return true;
        }
    }
}
