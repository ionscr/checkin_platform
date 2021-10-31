using Checkin_Platform.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Dto
{
    public class ClassroomDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public List<Feature> Features { get; set; }
    }
}
