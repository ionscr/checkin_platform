using AutoMapper;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.AutoMapperProfiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<SetUserDto, User>();
            CreateMap<GetUserDto, User>();
        }
    }
}
