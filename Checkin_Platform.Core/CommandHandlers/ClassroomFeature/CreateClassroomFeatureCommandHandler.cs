using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.ClassroomFeature;
using Checkin_Platform.Core.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.ClassroomFeature
{
    public class CreateClassroomFeatureCommandHandler: IRequestHandler<CreateClassroomFeatureCommand,bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateClassroomFeatureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateClassroomFeatureCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<SetClassroomFeatureDto, Domain.ClassroomFeature>(request.ClassroomFeatureDto);
            _unitOfWork.ClassroomFeatureRepository.AddClassroomFeature(item);
            _unitOfWork.SaveChanges();
            return true;

        }
    }
}
