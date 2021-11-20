using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class GetClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Teacher { get; set; }
        public int Year { get; set; }
        public string Section { get; set; }
    }
}
