using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Domain
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public List<Feature> Features { get; set; }
    }
}
