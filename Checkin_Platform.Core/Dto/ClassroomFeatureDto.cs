using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class ClassroomFeatureDto
    {
        public Feature Feature { get; set; }

        public Classroom Classroom { get; set; }

        public int FeatureId { get; set; }
        public int ClassroomId { get; set; }
    }
}
