using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class SetUserScheduleDto
    {
        public int ScheduleId { get; set; }
        public int UserId { get; set; }
    }
}
