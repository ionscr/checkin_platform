using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Schedule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Schedule
{
    public class GetSchedulesByUserReservationsQueryHandler : IRequestHandler<GetSchedulesByUserReservationsQuery, IEnumerable<GetScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetSchedulesByUserReservationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetScheduleDto>> Handle(GetSchedulesByUserReservationsQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.ScheduleRepository.GetSchedulesByUserReservations(request.UserId);
            var scheduleDtoList = new List<GetScheduleDto>();
            foreach (var item in scheduleList)
            {
                scheduleDtoList.Add(new GetScheduleDto
                {
                    Id = item.Id,
                    Class = item.Class,
                    Classroom = item.Classroom,
                    DateTime = item.DateTime
                });
            }
            return scheduleDtoList;
        }
    }
}
