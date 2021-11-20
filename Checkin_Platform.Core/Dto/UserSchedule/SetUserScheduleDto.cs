using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class SetUserScheduleDto
    {
        public Schedule Schedule { get; set; }
        public User User { get; set; }
    }
}
