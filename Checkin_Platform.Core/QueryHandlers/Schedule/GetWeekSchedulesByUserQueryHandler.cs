using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Dto.Schedule;
using Checkin_Platform.Core.Queries.Schedule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Schedule
{
    public class GetWeekSchedulesByUserQueryHandler : IRequestHandler<GetWeekSchedulesByUserQuery, IEnumerable<GetGroupScheduleDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetWeekSchedulesByUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetGroupScheduleDto>> Handle(GetWeekSchedulesByUserQuery request, CancellationToken cancellationToken)
        {
            var scheduleList = _unitOfWork.ScheduleRepository.GetWeekSchedulesByUser(request.StartDate, request.UserId);
            var scheduleDtoList = _mapper.Map<IEnumerable<GetGroupScheduleDtoUnfixed>, IEnumerable<GetGroupScheduleDto>>(scheduleList);
            foreach (var sc in scheduleDtoList)
            {
                foreach (var s in sc.Schedules)
                {
                    var users = _unitOfWork.UserRepository.GetUsersBySchedule(s.Id);
                    var usersDto = _mapper.Map<IEnumerable<Domain.User>, IEnumerable<GetUserDto>>(users);
                    s.Users = usersDto;
                }
            }
            return scheduleDtoList;
        }
    }
}
