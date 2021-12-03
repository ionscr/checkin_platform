using AutoMapper;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.AutoMapperProfiles
{
    class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, GetClassDto>();
            CreateMap<SetClassDto, Class>();
            CreateMap<GetClassDto, Class>();
        }
    }
}
