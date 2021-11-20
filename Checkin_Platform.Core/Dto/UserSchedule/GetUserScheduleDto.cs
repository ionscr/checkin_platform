using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class GetUserScheduleDto
    {
        public int Id { get; set; }
        public Schedule Schedule { get; set; }
        public User User { get; set; }
    }
}
