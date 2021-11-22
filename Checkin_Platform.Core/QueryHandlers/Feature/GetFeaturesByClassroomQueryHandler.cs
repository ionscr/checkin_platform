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
        public GetFeaturesByClassroomQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetFeatureDto>> Handle(GetFeaturesByClassroomQuery request, CancellationToken cancellationToken)
        {
            var featureList = _unitOfWork.FeatureRepository.GetFeaturesByClassroom(request.ClassroomId);
            var featureDtoList = new List<GetFeatureDto>();
            foreach (var item in featureList)
            {
                featureDtoList.Add(new GetFeatureDto
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return featureDtoList;
        }
    }
}
