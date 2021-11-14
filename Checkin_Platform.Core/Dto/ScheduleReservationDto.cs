using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class ScheduleReservationDto
    {
        public Schedule Schedule { get; set; }
        public User Student { get; set; }
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
    }
}
