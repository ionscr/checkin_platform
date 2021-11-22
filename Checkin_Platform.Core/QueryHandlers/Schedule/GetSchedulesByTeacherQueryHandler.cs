using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Schedule;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Schedule
{
    public class GetSchedulesByTeacherQueryHandler: IRequestHandler<GetSchedulesByTeacherQuery, IEnumerable<GetScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetSchedulesByTeacherQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetScheduleDto>> Handle(GetSchedulesByTeacherQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.ScheduleRepository.GetSchedulesByTeacher(request.TeacherId);
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
