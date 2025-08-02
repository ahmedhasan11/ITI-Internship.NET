using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ITI_DBFirst_COmpanyDB
{
    internal class Program
    {
       // public CompanyItiDbfirstContext context = new CompanyItiDbfirstContext();

		static void Main(string[] args)
        {
			var context = new CompanyItiDbfirstContext();
			while (true)
			{


				Console.WriteLine("enter option:   ");

				Console.WriteLine("1-add Department");
				Console.WriteLine("2-add employee");
				Console.WriteLine("3-add Project");
				Console.WriteLine("4-link emp to project");
				Console.WriteLine("5-display employee table");
				Console.WriteLine("6-displaydepartment table");
				Console.WriteLine("7-display project table");
				string option = Console.ReadLine();
				switch (option)
				{
					case "1":
						//Department
						#region Department
						Department dept = new Department();
						Console.WriteLine("enter dept name");
						dept.Name = Console.ReadLine();
						context.Departments.Add(dept);
						context.SaveChanges();
						#endregion
						break;
					case "2":
						//Employee
						#region Employee
						Employee employee = new Employee();
						Console.WriteLine("enter employee data");
						Console.WriteLine("FN:");
						employee.FirstName = Console.ReadLine();
						Console.WriteLine("LN:");
						employee.LastName = Console.ReadLine();
						Console.WriteLine("enter dept id");
						employee.DepartmentId = int.Parse(Console.ReadLine());
						context.Employees.Add(employee);
						context.SaveChanges();
						#endregion
						break;
					case "3":
						//Project
						#region Project
						Project project = new Project();
						Console.WriteLine("enter project name");
						project.Name = Console.ReadLine();
						Console.WriteLine("start date:");
						project.StartDate = DateOnly.Parse(Console.ReadLine());
						Console.WriteLine("end date:");
						project.EndDate = DateOnly.Parse(Console.ReadLine());
						context.Projects.Add(project);
						context.SaveChanges();
						#endregion
						break;
					case "4":
						#region EmployeeProject
						EmployeeProject employeeProject = new EmployeeProject();
						Console.WriteLine("enter id ot the empyou need to link");
						employeeProject.EmployeeId = int.Parse(Console.ReadLine());
						Console.WriteLine("enter id ot the project you need to link");
						employeeProject.ProjectId = int.Parse(Console.ReadLine());
						Console.WriteLine("enter the role of theemployee inthe project");
						employeeProject.Role = Console.ReadLine();

						context.EmployeeProjects.Add(employeeProject);
						context.SaveChanges();
						#endregion
						break;

					case "5":
						foreach(var emp in context.Employees.Include(e=>e.Department).Include(e=>e.EmployeeProjects).ThenInclude(ep=>ep.Project))
						{
							Console.WriteLine($"employee id:{emp.EmployeeId}");
							Console.WriteLine($"employee fname:{emp.FirstName}");
							Console.WriteLine($"employee lname:{emp.LastName}");
							Console.WriteLine($"employee dept id:{emp.DepartmentId}");
							Console.WriteLine($"employee dept name:{emp.Department?.Name}");
							Console.WriteLine($"projects:");
							foreach (var projectt in emp.EmployeeProjects)
							{
								Console.WriteLine($"employee role is:{projectt.Role}");
								Console.WriteLine($"project name:{projectt.Project.Name}");
							}
							Console.WriteLine("******************************************");

						}
						break;

					case "6":
						foreach(var department in context.Departments.Include(d=>d.Employees))
						{
							Console.WriteLine($"dept id:{department.DepartmentId}");
							Console.WriteLine($"dept name:{department.Name}");
							Console.WriteLine($"dept employees:");
							foreach (var emp in department.Employees)
							{
								Console.WriteLine(emp.FirstName);

							}
							Console.WriteLine("******************************************");
						}
						break;

					case "7":
						foreach (var proj in context.Projects.Include(p=>p.EmployeeProjects).ThenInclude(ep=>ep.Employee))
						{
							Console.WriteLine($"projectID:{proj.ProjectId}");
							Console.WriteLine($"project name:{proj.Name}");
							Console.WriteLine($"project start date:{proj.StartDate}");
							Console.WriteLine($"project end date:{proj.EndDate}");
							Console.WriteLine("employees workson the project:");
							foreach (var ep in proj.EmployeeProjects)
							{
								Console.WriteLine($"{ep.Employee.FirstName}");
							}
							Console.WriteLine("******************************************");
						}
						break;

				}

			}


		}

	}
}
