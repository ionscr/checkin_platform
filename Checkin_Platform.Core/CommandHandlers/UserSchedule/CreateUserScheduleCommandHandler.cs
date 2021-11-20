using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.UserSchedule;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.UserSchedule
{
    public class CreateUserScheduleCommandHandler: IRequest<bool>
    {
        private IUnitOfWork _unitOfWork;

        public CreateUserScheduleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateUserScheduleCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.UserScheduleRepository.AddUserSchedule(new Domain.UserSchedule
            {
                Schedule = request.UserScheduleDto.Schedule,
                User = request.UserScheduleDto.User
            });
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
