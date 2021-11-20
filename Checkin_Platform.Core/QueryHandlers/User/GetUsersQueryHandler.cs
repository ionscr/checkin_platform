using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.User;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.User
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUserDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userList = _unitOfWork.UserRepository.GetUsers();
            var userDtoList = new List<GetUserDto>();
            foreach (var item in userList)
            {
                userDtoList.Add(new GetUserDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Role = item.Role,
                    Department = item.Department,
                    Group = item.Group,
                    Year = item.Year
                });
            }
            return userDtoList;
        }
    }
}