using AutoMapper;
using Checkin_Platform.Core.Dto;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.AutoMapperProfiles
{
    class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, GetScheduleDto>();
            CreateMap<SetScheduleDto, Schedule>();
        }
    }
}
