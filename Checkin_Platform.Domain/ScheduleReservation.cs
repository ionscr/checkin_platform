namespace Checkin_Platform.Domain
{
    public class ScheduleReservation
    {
        public int Id { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
