using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OOP_Employee
{
	public class Employee
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

		public Employee(int id , string name , double salary , int age)
		{
			Employee_ID = id;
			Employee_Name = name;
			Salary = salary;
			Age = age;

		}
		public void DisplayMethod(/*int id, string name, double salary, int Age*/)
		{
			Console.WriteLine(" Employee Data ");
			Console.WriteLine("ID: " + Employee_ID);
			Console.WriteLine("Name: " + Employee_Name);
			Console.WriteLine("Salary: " + Salary);
			Console.WriteLine("Age" + Age);
		}
	}
	

	
}