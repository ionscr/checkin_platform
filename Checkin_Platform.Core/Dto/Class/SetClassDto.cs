using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class SetClassDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public string Section { get; set; }
    }
}
