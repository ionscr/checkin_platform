using AutoMapper;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.AutoMapperProfiles
{
    class ClassroomFeatureProfile : Profile
    {
        public ClassroomFeatureProfile()
        {
            CreateMap<ClassroomFeature, GetClassroomFeatureDto>();
            CreateMap<SetClassroomFeatureDto, ClassroomFeature>();
        }
    }
}
