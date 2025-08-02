using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System
{
    class Department
    {
        public int DepartmentID { get; set; }
		public string Department_Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

	}
}
