﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System
{
    class Employee_Project
    {
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }

        public string Role { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
