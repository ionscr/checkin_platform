using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Schedule;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Schedule
{
    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, IEnumerable<ScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetSchedulesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ScheduleDto>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.Schedule.ToList();
            var scheduleDtoList = new List<ScheduleDto>();
            foreach (var item in scheduleList)
            {
                scheduleDtoList.Add(new ScheduleDto
                {
                    Classn = item.Classn,
                    Classroom = item.Classroom,
                    DateTime = item.DateTime,
                    ScheduleReservations = item.ScheduleReservations
                });
            }
            return scheduleDtoList;
        }
    }
}
