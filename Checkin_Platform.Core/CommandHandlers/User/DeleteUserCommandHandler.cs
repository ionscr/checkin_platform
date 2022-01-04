using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.User;
using Checkin_Platform.Core.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.UserRepository.GetUserById(request.Id);

            if (item == null)
            {
                throw new EntityNotFoundException("User", request.Id);
            }
            _unitOfWork.UserRepository.DeleteUser(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
