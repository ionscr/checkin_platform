using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Schedule;
using Checkin_Platform.Core.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Schedule
{
    public class CreateScheduleCommandHandler: IRequestHandler<CreateScheduleCommand,bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<SetScheduleDto, Domain.Schedule>(request.ScheduleDto);
            item.Class = _unitOfWork.ClassRepository.GetClassById(request.ScheduleDto.ClassId);
            item.Classroom = _unitOfWork.ClassroomRepository.GetClassroomById(request.ScheduleDto.ClassroomId);
            _unitOfWork.ScheduleRepository.AddSchedule(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
