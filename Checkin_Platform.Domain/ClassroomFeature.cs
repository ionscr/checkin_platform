namespace Checkin_Platform.Domain
{
    public class ClassroomFeature
    {
        public int Id { get; set; }
        public Feature Feature { get; set; }

        public Classroom Classroom { get; set; }

        public int FeatureId { get; set; }
        public int ClassroomId { get; set; }
    }
}
