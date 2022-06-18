using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.User;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Checkin_Platform.Core.QueryHandlers.User
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, GetUserDto>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public LoginUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetUserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var userList = _unitOfWork.UserRepository.GetUsers();
            var user = userList.FirstOrDefault(x => x.Email == request.UserDto.Email);
            if (user != null && BC.Verify(request.UserDto.Password, user.Password))
            {
                return _mapper.Map<Domain.User, GetUserDto>(user);
            }
            else return new GetUserDto()
            {
                Id = -1
            };
        }
    }
}
