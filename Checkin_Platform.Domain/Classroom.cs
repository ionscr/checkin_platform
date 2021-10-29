using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Domain
{
    class Classroom
    {
        private long id;
        private string name;
        private string location;
        private int capacity;

        public Classroom()
        {
        }

        public Classroom(string name, string location, int capacity)
        {
            this.name = name;
            this.location = location;
            this.capacity = capacity;
        }
    }
}
