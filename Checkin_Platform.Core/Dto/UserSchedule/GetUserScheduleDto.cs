using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class GetUserScheduleDto
    {
        public int Id { get; set; }
        public GetScheduleDto Schedule { get; set; }
        public GetUserDto User { get; set; }
    }
}
