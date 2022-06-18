namespace Checkin_Platform.Core.Dto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? Year { get; set; }
        public string? Department { get; set; }
        public string? Group { get; set; }
    }
}
