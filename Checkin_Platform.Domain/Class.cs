using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Domain
{
    class Class
    {
        private long id;
        private string name;
        private User teacher;
        private int year;
        private string section;

        public Class()
        {
        }
        public Class(string name, User teacher, int year, string section)
        {
            this.name = name;
            this.teacher = teacher;
            this.year = year;
            this.section = section;
        }
    }
}
