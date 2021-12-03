using AutoMapper;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.AutoMapperProfiles
{
    class ClassroomProfile : Profile
    {
        public ClassroomProfile()
        {
            CreateMap<Classroom, GetClassroomDto>();
            CreateMap<SetClassroomDto, Classroom>();
        }
    }
}
