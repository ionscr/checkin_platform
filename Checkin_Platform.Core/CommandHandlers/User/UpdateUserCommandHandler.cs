using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.UserRepository.GetUserById(request.userDto.Id);
            item.FirstName = request.userDto.FirstName;
            item.LastName = request.userDto.LastName;
            if(item.Role == "Student")
            {
                item.Year = request.userDto.Year;
                item.Group = request.userDto.Group;
            }
            if(item.Role == "Teacher") item.Department = request.userDto.Department;
            _unitOfWork.UserRepository.UpdateUser(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
