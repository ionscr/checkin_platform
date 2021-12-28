using Checkin_Platform.Core.Dto;
using MediatR;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Queries.Feature
{
    public class GetOtherFeaturesByClassroomQuery : IRequest<IEnumerable<GetFeatureDto>>
    {
        public int ClassroomId { get; set; }
    }
}
