using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System
{
    class Project
    {
		public int ProjectID { get; set; }
		public string Project_Name { get; set; }

		public DateOnly StartDate { get; set; }
		public DateOnly EndDate { get; set; }
		public ICollection<Employee_Project> Emp_proj { get; set; }
	}
}
