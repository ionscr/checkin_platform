using AutoMapper;
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
    public class GetSchedulesByDateQueryHandler : IRequestHandler<GetSchedulesByDateQuery, IEnumerable<GetScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetSchedulesByDateQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetScheduleDto>> Handle(GetSchedulesByDateQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.ScheduleRepository.GetSchedulesByDate(request.DateTime);
            var scheduleDtoList = _mapper.Map<IEnumerable<Domain.Schedule>, IEnumerable<GetScheduleDto>>(scheduleList);
            return scheduleDtoList;
        }
    }
}
