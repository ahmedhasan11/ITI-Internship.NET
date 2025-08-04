using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVC_D2_Employee_DeptSystsem.Models
{
	public class Employee
	{
		public int EmployeeID { get; set; }

		public string EmployeeName { get; set; }

		public int Dept_ID { get; set; }

		[ValidateNever]
		public Department Department { get; set; }
	}
}
