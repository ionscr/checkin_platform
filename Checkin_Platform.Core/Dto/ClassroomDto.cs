using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Dto
{
    public class ClassroomDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public List<ClassroomFeature> ClassroomFeatures { get; set; }
    }
}
