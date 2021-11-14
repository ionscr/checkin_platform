using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.ScheduleReservation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.ScheduleReservation
{
    public class GetScheduleReservationsQueryHandler : IRequestHandler<GetScheduleReservationsQuery, IEnumerable<ScheduleReservationDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetScheduleReservationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ScheduleReservationDto>> Handle(GetScheduleReservationsQuery request, CancellationToken cancellationToken)
        {
            var scheduleReservationList = _unitOfWork.ScheduleReservation.ToList();
            var scheduleReservationDtoList = new List<ScheduleReservationDto>();
            foreach (var item in scheduleReservationList)
            {
                scheduleReservationDtoList.Add(new ScheduleReservationDto
                {
                    Schedule = item.Schedule,
                    Student = item.Student,
                    ScheduleId = item.ScheduleId,
                    StudentId = item.StudentId
                });
            }
            return scheduleReservationDtoList;
        }
    }
}
