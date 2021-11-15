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
    public class GetSchedulesByDateQueryHandler : IRequestHandler<GetSchedulesByDateQuery, IEnumerable<ScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetSchedulesByDateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ScheduleDto>> Handle(GetSchedulesByDateQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.Schedule.Where(s => s.DateTime.Date == request.DateTime.Date );
            var scheduleDtoList = new List<ScheduleDto>();
            foreach (var item in scheduleList)
            {
                scheduleDtoList.Add(new ScheduleDto
                {
                    Classn = item.Classn,
                    Classroom = item.Classroom,
                    DateTime = item.DateTime
                });
            }
            return scheduleDtoList;
        }
    }
}
