using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class GetClassroomFeatureDto
    {
        public int Id { get; set; }
        public GetFeatureDto Feature { get; set; }

        public GetClassroomDto Classroom { get; set; }
    }
}
