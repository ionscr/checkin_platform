using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Commands.Feature;
using Checkin_Platform.Core.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.CommandHandlers.Feature
{
    public class CreateFeatureCommandHandler: IRequest<bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateFeatureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<SetFeatureDto, Domain.Feature>(request.FeatureDto);
            _unitOfWork.FeatureRepository.AddFeature(item);
            _unitOfWork.SaveChanges();
            return true;
        }

    }
}
