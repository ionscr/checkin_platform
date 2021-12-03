using AutoMapper;
using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Core.Queries.ClassroomFeature;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Checkin_Platform.Core.QueryHandlers.ClassroomFeature
{
    public class GetClassroomFeaturesQueryHandler : IRequestHandler<GetClassroomFeaturesQuery, IEnumerable<GetClassroomFeatureDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetClassroomFeaturesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetClassroomFeatureDto>> Handle(GetClassroomFeaturesQuery request, CancellationToken cancellationToken)
        {
            var classroomFeatureList = _unitOfWork.ClassroomFeatureRepository.GetClassroomFeatures();
            var classroomFeatureDtoList = _mapper.Map<IEnumerable<Domain.ClassroomFeature>, IEnumerable<GetClassroomFeatureDto>>(classroomFeatureList);
            return classroomFeatureDtoList;
        }
    }
}
