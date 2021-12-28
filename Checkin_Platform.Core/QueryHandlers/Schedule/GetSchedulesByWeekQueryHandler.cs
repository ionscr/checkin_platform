using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Dto.Schedule;
using Checkin_Platform.Core.Queries.Schedule;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Schedule
{
    public class GetSchedulesByWeekQueryHandler : IRequestHandler<GetSchedulesByWeekQuery, IEnumerable<GetGroupScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetSchedulesByWeekQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetGroupScheduleDto>> Handle(GetSchedulesByWeekQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.ScheduleRepository.GetSchedulesByWeek(request.StartDate);
            var scheduleDtoList = _mapper.Map<IEnumerable<GetGroupScheduleDtoUnfixed>, IEnumerable<GetGroupScheduleDto>>(scheduleList);
            return scheduleDtoList;
        }
    }
}
