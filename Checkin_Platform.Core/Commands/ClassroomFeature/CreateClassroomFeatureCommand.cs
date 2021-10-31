using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Commands.ClassroomFeature
{
    public class CreateClassroomFeatureCommand: IRequest<bool>
    {
        public ClassroomFeatureDto ClassroomFeatureDto { get; set; }
    }
}
