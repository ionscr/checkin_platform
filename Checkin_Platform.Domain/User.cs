using System.Collections.Generic;

namespace Checkin_Platform.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int? Year { get; set; }
        public string? Department { get; set; }
        public string? Group { get; set; }

        public List<UserSchedule> UserSchedule { get; set; }
        public List<Class>? Classes { get; set; }
    }
}
