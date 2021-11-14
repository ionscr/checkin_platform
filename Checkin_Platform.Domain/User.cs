using System.Collections.Generic;

namespace Checkin_Platform.Domain
{
    public class User
    {
        private int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public int Year { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }

        public List<ScheduleReservation> ScheduleReservations { get; set; }
    }
}
