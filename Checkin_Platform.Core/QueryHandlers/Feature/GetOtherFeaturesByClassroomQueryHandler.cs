using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.Feature;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.Feature
{
    public class GetOtherFeaturesByClassroomQueryHandler : IRequestHandler<GetOtherFeaturesByClassroomQuery, IEnumerable<GetFeatureDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetOtherFeaturesByClassroomQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetFeatureDto>> Handle(GetOtherFeaturesByClassroomQuery request, CancellationToken cancellationToken)
        {
            var featureList = _unitOfWork.FeatureRepository.GetOtherFeaturesByClassroom(request.ClassroomId);
            var featureDtoList = _mapper.Map<IEnumerable<Domain.Feature>, IEnumerable<GetFeatureDto>>(featureList);
            return featureDtoList;
        }
    }
}
