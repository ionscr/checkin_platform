using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.UserSchedule;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.UserSchedule
{
    public class GetUserSchedulesQueryHandler : IRequestHandler<GetUserSchedulesQuery, IEnumerable<UserScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetUserSchedulesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserScheduleDto>> Handle(GetUserSchedulesQuery request, CancellationToken cancellationToken)
        {
            var userScheduleList = _unitOfWork.UserScheduleRepository.GetUserSchedules();
            var userScheduleDtoList = new List<UserScheduleDto>();
            foreach (var item in userScheduleList)
            {
                userScheduleDtoList.Add(new UserScheduleDto
                {
                    Schedule = item.Schedule,
                    Student = item.User
                });
            }
            return userScheduleDtoList;
        }
    }
}
