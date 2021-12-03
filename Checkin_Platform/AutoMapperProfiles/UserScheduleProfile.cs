using AutoMapper;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.AutoMapperProfiles
{
    class UserScheduleProfile : Profile
    {
        public UserScheduleProfile()
        {
            CreateMap<UserSchedule, GetUserScheduleDto>();
            CreateMap<SetUserScheduleDto, UserSchedule>();
        }
    }
}
