using Microsoft.EntityFrameworkCore;
using MVC_D2_Employee_DeptSystsem.Models;
using System.Data;
namespace MVC_D2_Employee_DeptSystsem.Data
{
	public class SystemContext:DbContext
	{
		public SystemContext(DbContextOptions<SystemContext> options) : base(options)
		{

		}
		
		public DbSet<Employee> Employee { get; set; }

		public DbSet<Department> Department { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>().HasOne(e=>e.Department).WithMany(d => d.Employees)
				.HasForeignKey(e=>e.Dept_ID);

			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentID=1, DepartmentName="HR"},
				new Department { DepartmentID = 2, DepartmentName = "Event Operation" },
				new Department { DepartmentID = 3, DepartmentName = "R&D" });

			modelBuilder.Entity<Employee>().HasData(
				new Employee {EmployeeID=1,EmployeeName="ahmed",Dept_ID=1 },
				new Employee { EmployeeID = 2, EmployeeName = "ayman", Dept_ID = 1 },

				new Employee { EmployeeID = 3, EmployeeName = "mohammed", Dept_ID = 2 },
				new Employee { EmployeeID = 4, EmployeeName = "mahmoud", Dept_ID = 3 });


			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
