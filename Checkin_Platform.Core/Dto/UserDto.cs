﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Checkin_Platform.Core.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public int Year { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }
    }
}
