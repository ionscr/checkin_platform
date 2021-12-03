using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Class;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Class
{
    public class CreateClassCommandHandler: IRequestHandler<CreateClassCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateClassCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {

            var item = _mapper.Map<SetClassDto, Domain.Class>(request.ClassDto);
            item.Teacher = _unitOfWork.UserRepository.GetUserById(request.ClassDto.UserId);
            _unitOfWork.ClassRepository.AddClass(item);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
