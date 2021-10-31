using Checkin_Platform.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Dto
{
    public class ClassDto
    {
        public string Name { get; set; }
        public User Teacher { get; set; }
        public int Year { get; set; }
        public string Section { get; set; }
    }
}
