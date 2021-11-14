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
    public class GetFeaturesQueryHandler : IRequestHandler<GetFeaturesQuery, IEnumerable<FeatureDto>>
    {
        private IUnitOfWork _unitOfWork;
        public GetFeaturesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<FeatureDto>> Handle(GetFeaturesQuery request, CancellationToken cancellationToken)
        {
            var featureList = _unitOfWork.Feature.ToList();
            var featureDtoList = new List<FeatureDto>();
            foreach (var item in featureList)
            {
                featureDtoList.Add(new FeatureDto
                {
                    Nume = item.Nume,
                    ClassroomFeatures = item.ClassroomFeatures
                });
            }
            return featureDtoList;
        }
    }
}
