using System.Collections.Generic;

namespace Checkin_Platform.Domain
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public List<ClassroomFeature> ClassroomFeatures { get; set; }
    }
}
