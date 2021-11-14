using System.Collections.Generic;
using Checkin_Platform.Domain;

namespace Checkin_Platform.Core.Dto
{
    public class FeatureDto
    {
        public string Nume { get; set; }
        public List<ClassroomFeature> ClassroomFeatures { get; set; }
    }
}
