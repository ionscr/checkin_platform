using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Queries.ClassroomFeature
{
    public class GetClassroomFeaturesQuery : IRequest<IEnumerable<ClassroomFeatureDto>>
    {
    }
}
