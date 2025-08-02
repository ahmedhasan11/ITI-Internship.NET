using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System
{
	class CompanyContext : DbContext
	{
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Department> Department { get; set; }
		public DbSet<Project> Projects { get; set; }

		public DbSet<Employee_Project> Employee_Projects { get; set; }

		public CompanyContext():base()
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Department>().HasMany(d => d.Employees);
			//modelBuilder.Entity<Employee>().HasOne(e => e.Department);
			modelBuilder.Entity<Employee_Project>().HasKey(ep => new
			{
				ep.ProjectID,
				ep.EmployeeID
			});

			modelBuilder.Entity<Employee_Project>().HasOne(ep => ep.Employee).WithMany(ep => ep.Emp_proj).HasForeignKey(ep=>ep.EmployeeID);
			modelBuilder.Entity<Employee_Project>().HasOne(ep => ep.Project).WithMany(ep => ep.Emp_proj).HasForeignKey(ep=>ep.ProjectID);




			base.OnModelCreating(modelBuilder);
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite((@"Data Source=""C:\Users\user\source\repos\ITI-Internship\Day6\Company System\Company System\Company.db"""));
			base.OnConfiguring(optionsBuilder);
		}


	}
}
