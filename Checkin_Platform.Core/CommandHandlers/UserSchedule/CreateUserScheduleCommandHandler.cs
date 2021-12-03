using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.UserSchedule;
using Checkin_Platform.Core.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.UserSchedule
{
    public class CreateUserScheduleCommandHandler: IRequest<bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateUserScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserScheduleCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<SetUserScheduleDto, Domain.UserSchedule>(request.UserScheduleDto);
            _unitOfWork.UserScheduleRepository.AddUserSchedule(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
