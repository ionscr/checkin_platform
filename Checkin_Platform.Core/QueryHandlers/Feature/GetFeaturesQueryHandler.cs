using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Feature;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Feature
{
    public class GetFeaturesQueryHandler : IRequestHandler<GetFeaturesQuery, IEnumerable<GetFeatureDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetFeaturesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetFeatureDto>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
        {
            var featureList = _unitOfWork.FeatureRepository.GetFeatures();
            var featureDtoList = _mapper.Map<IEnumerable<Domain.Feature>, IEnumerable<GetFeatureDto>>(featureList);
            return featureDtoList;
        }
    }
}
