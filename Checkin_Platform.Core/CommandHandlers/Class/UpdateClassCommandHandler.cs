using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Class;
using Checkin_Platform.Core.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public UpdateClassCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            var item = _unitOfWork.ClassRepository.GetClassById(request.ClassDto.Id);
            item.Name = request.ClassDto.Name;
            item.Section = request.ClassDto.Section;
            item.Teacher = _unitOfWork.UserRepository.GetUserById(request.ClassDto.Teacher.Id);
            item.Year = request.ClassDto.Year;
            _unitOfWork.ClassRepository.UpdateClass(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
