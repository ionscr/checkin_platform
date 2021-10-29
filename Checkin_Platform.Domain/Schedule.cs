using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Domain
{
    class Schedule
    {
        private long id;
        private DateTime dateTime;
        private Classroom classroom;
        private Class classn;

        public Schedule()
        {
        }

        public Schedule(DateTime dateTime, Classroom classroom, Class classn)
        {
            this.dateTime = dateTime;
            this.classroom = classroom;
            this.classn = classn;
        }
    }
}
