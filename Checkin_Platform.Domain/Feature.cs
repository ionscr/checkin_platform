using System.Collections.Generic;

namespace Checkin_Platform.Domain
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ClassroomFeature> ClassroomFeatures { get; set; }
    }
}
