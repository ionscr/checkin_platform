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
    public class GetFeaturesByClassroomQueryHandler : IRequestHandler<GetFeaturesByClassroomQuery, IEnumerable<GetFeatureDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetFeaturesByClassroomQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetFeatureDto>> Handle(GetFeaturesByClassroomQuery request, CancellationToken cancellationToken)
        {
            var featureList = _unitOfWork.FeatureRepository.GetFeaturesByClassroom(request.ClassroomId);
            var featureDtoList = _mapper.Map<IEnumerable<Domain.Feature>, IEnumerable<GetFeatureDto>>(featureList);
            return featureDtoList;
        }
    }
}
