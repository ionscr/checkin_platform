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
    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, IEnumerable<GetScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetSchedulesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetScheduleDto>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.ScheduleRepository.GetSchedules();
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
