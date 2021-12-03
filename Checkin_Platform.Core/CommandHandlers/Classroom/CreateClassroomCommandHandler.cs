using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Classroom;
using Checkin_Platform.Core.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Classroom
{
    public class CreateClassroomCommandHandler: IRequestHandler<CreateClassroomCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateClassroomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<SetClassroomDto, Domain.Classroom>(request.ClassroomDto);
            _unitOfWork.ClassroomRepository.AddClassroom(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
