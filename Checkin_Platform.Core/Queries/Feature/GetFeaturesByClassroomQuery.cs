using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Queries.Feature
{
    public class GetFeaturesByClassroomQuery : IRequest<IEnumerable<GetFeatureDto>>
    {
        public int ClassroomId { get; set; }
    }
}
