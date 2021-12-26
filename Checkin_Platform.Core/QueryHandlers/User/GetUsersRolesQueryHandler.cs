using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Queries.User;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.User
{
    public class GetUsersRolesQueryHandler : IRequestHandler<GetUsersRolesQuery, IEnumerable<string>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetUsersRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<string>> Handle(GetUsersRolesQuery request, CancellationToken cancellationToken)
        {
            var rolesList = _unitOfWork.UserRepository.GetUsersRoles();
            return rolesList;
        }
    }
}
