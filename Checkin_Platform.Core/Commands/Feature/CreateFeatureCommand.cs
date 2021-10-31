using Checkin_Platform.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Commands.Feature
{
    public class CreateFeatureCommand: IRequest<bool>
    {
        public FeatureDto FeatureDto { get; set; }
    }
}
