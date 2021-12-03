using Checkin_Platform.Core.Dto;
using MediatR;

namespace Checkin_Platform.Core.Commands.Feature
{
    public class UpdateFeatureCommand : IRequest<bool>
    {
        public GetFeatureDto FeatureDto { get; set; }
    }
}
