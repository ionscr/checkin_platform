using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class SetClassroomFeatureDto
    {
        public Feature Feature { get; set; }

        public Classroom Classroom { get; set; }
    }
}
