using System.Collections.Generic;

namespace Checkin_Platform.Domain
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Teacher { get; set; }
        public int UserId { get; set; }
        public int Year {get; set; }
        public string Section { get; set; }

        public List<Schedule> Schedules { get; set; } 
    }
}
