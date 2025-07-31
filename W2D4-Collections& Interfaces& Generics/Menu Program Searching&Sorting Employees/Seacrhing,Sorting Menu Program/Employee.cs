using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seacrhing_Sorting_Menu_Program
{
	public class Employee:IComparable<Employee>
	{
		public int Employee_ID { get; set; }
		public string Employee_Name { get; set; }

		public double Salary { get; set; }

		private int age;
		public int Age
		{
			get { return age; }
			set
			{
				if (value >= 18 && value <= 60)
				{
					age = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Age must be between 18 and 60.");
				}
			}
		}
		public Employee(int id, string name, double salary, int age)
		{
			Employee_ID = id;
			Employee_Name = name;
			Salary = salary;
			Age = age;

		}
		public static Employee Search_Employee_By_ID(List<Employee> Emps)
		{
			Console.WriteLine("enter id of the Employee");
			int id = int.Parse(Console.ReadLine());
			foreach (var emp in Emps)
			{
				if (emp.Employee_ID == id)
				{

					Console.WriteLine($"{emp.Employee_ID}");
					Console.WriteLine($"{emp.Employee_Name} ");
					Console.WriteLine($"{emp.Age} ");
					Console.WriteLine($"{emp.Salary}");
					return emp;
					
				}

			}
			Console.WriteLine("employee not found");
			return null;
		}
		public static  Employee Search_Employee_By_Name(List<Employee> Emps)
		{
			Console.WriteLine("enter  Name of Employee");
			string name = Console.ReadLine();
			foreach (var Emp in Emps)
			{
				if (Emp.Employee_Name==name)
				{
					Console.WriteLine($"{Emp.Employee_ID}");
					Console.WriteLine($"{Emp.Employee_Name} ");
					Console.WriteLine($"{Emp.Age} ");
					Console.WriteLine($"{Emp.Salary}");
					return Emp;
				}
			}
			Console.WriteLine("Emp not found");
			return null;
		}
		//public Employee Sort_ID(List<Employee> Emps):
		//{
		//}
		public int CompareTo(Employee? other)
		{
			throw new NotImplementedException();
		}


		//public void DisplayMethod(/*int id, string name, double salary, int Age*/)
		//{
		//	Console.WriteLine(" Employee Data ");
		//	Console.WriteLine("ID: " + Employee_ID);
		//	Console.WriteLine("Name: " + Employee_Name);
		//	Console.WriteLine("Salary: " + Salary);
		//	Console.WriteLine("Age" + Age);
		//}
	}

	public class Sort_By_ID : IComparer<Employee>
	{

		public int Compare(Employee? x, Employee? y)
		{
			return x.Employee_ID.CompareTo(y.Employee_ID);
		}
	}
	public class Sort_By_Name : IComparer<Employee>
	{

		public int Compare(Employee? x, Employee? y)
		{
			return x.Employee_Name.CompareTo(y.Employee_Name);
		}
	}
	public class Sort_By_Salary : IComparer<Employee>
	{

		public int Compare(Employee? x, Employee? y)
		{
			return x.Salary.CompareTo(y.Salary);
		}
	}
}
