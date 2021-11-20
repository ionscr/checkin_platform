using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class GetClassroomFeatureDto
    {
        public int Id { get; set; }
        public Feature Feature { get; set; }

        public Classroom Classroom { get; set; }
    }
}
