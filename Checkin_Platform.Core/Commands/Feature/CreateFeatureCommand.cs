using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.Feature
{
    public class CreateFeatureCommand: IRequest<bool>
    {
        public FeatureDto FeatureDto { get; set; }
    }
}
