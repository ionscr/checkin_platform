using AutoMapper;
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
    public class GetUserSchedulesQueryHandler : IRequestHandler<GetUserSchedulesQuery, IEnumerable<GetUserScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetUserSchedulesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUserScheduleDto>> Handle(GetUserSchedulesQuery request, CancellationToken cancellationToken)
        {
            var userScheduleList = _unitOfWork.UserScheduleRepository.GetUserSchedules();
            var userScheduleDtoList = _mapper.Map<IEnumerable<Domain.UserSchedule>, IEnumerable<GetUserScheduleDto>>(userScheduleList);
            return userScheduleDtoList;
        }
    }
}
