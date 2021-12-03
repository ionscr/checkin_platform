using AutoMapper;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.AutoMapperProfiles
{
    class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, GetFeatureDto>();
            CreateMap<SetFeatureDto, Feature>();
        }
    }
}
