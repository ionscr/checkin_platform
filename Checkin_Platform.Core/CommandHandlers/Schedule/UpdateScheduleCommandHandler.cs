using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Schedule;
using Checkin_Platform.Core.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Schedule
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UpdateScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ScheduleRepository.GetScheduleById(request.ScheduleDto.Id);
            item.DateTime = request.ScheduleDto.DateTime;
            item.Class = _unitOfWork.ClassRepository.GetClassById(request.ScheduleDto.Class.Id);
            item.Classroom = _unitOfWork.ClassroomRepository.GetClassroomById(request.ScheduleDto.Classroom.Id);
            _unitOfWork.ScheduleRepository.UpdateSchedule(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
