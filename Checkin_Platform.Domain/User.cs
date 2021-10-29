using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Domain
{
    class User
    {
        private long id;
        private string first_name;
        private string last_name;
        private int role;
        private int year;
        private string department;
        private string section;
        private string group;

        public User()
        {
        }

        public User(string first_name, string last_name, int role)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.role = role;
        }

        public User(string first_name, string last_name, int role, int year, string department, string section, string group) : this(first_name, last_name, role)
        {
            this.year = year;
            this.department = department;
            this.section = section;
            this.group = group;
        }
    }
}
