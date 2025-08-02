using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System
{
    class Employee
    {
		public int EmployeeID { get; set; }
		public string Employee_Firstname { get; set; }
		public string Employee_Lastname { get; set; }

		public int? DepartmentID { get; set; }
		public Department Department { get; set; }
		public ICollection<Employee_Project> Emp_proj { get; set; }
	}
}
