using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.User.Add(new Domain.User
            {
                FirstName = request.UserDto.FirstName,
                LastName = request.UserDto.LastName,
                Role = request.UserDto.Role,
                Department = request.UserDto.Department,
                Group = request.UserDto.Group,
                Year = request.UserDto.Year
            }) ;
            return true;
        }
    }
}
