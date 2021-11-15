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
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleDto>
    {
        private IUnitOfWork _unitOfWork;
        public GetScheduleByIdQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<ScheduleDto> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = _unitOfWork.Schedule.Where(s => s.Id == request.Id);
            var scheduleDto = new ScheduleDto();
            foreach (var item in schedule)
            {

                scheduleDto.Classn = item.Classn;
                scheduleDto.Classroom = item.Classroom;
                scheduleDto.DateTime = item.DateTime;
              
            }
            return scheduleDto;
        }
    }
}
