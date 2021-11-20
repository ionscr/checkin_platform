namespace Checkin_Platform.Core.Dto
{
    public class SetUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int? Year { get; set; }
        public string? Department { get; set; }
        public string? Group { get; set; }   
    }
}
