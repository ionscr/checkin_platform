using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.User;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.User
{
    public class GetUsersByRoleQueryHandler : IRequestHandler<GetUsersByRoleQuery, IEnumerable<GetUserDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetUsersByRoleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUserDto>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
        {
            var userList = _unitOfWork.UserRepository.GetUsersByRole(request.role);
            var userDtoList = _mapper.Map<IEnumerable<Domain.User>, IEnumerable<GetUserDto>>(userList);
            return userDtoList;
        }
    }
}
