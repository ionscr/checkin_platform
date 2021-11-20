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
        public GetClassroomFeaturesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetClassroomFeatureDto>> Handle(GetClassroomFeaturesQuery request, CancellationToken cancellationToken)
        {
            var classroomFeatureList = _unitOfWork.ClassroomFeatureRepository.GetClassroomFeatures();
            var classroomFeatureDtoList = new List<GetClassroomFeatureDto>();
            foreach (var item in classroomFeatureList)
            {
                classroomFeatureDtoList.Add(new GetClassroomFeatureDto
                {
                    Id = item.Id,
                    Classroom = item.Classroom,
                    Feature = item.Feature
                });
            }
            return classroomFeatureDtoList;
        }
    }
}
