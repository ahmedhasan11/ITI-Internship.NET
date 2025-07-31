using System;

class Program
{
	static void Main()
	{
		int id = 0;
		string name = "";
		float salary = 0;
		bool dataEntered = false;

		int choice;

		do
		{
			Console.WriteLine(" Menu ");
			Console.WriteLine("1. New");
			Console.WriteLine("2. Display");
			Console.WriteLine("3. Exit");
			Console.Write("Enter choice : ");
			choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 1:
					NewMethod(ref id, ref name, ref salary);
					dataEntered = true;
					break;

				case 2:
					if (dataEntered)
						DisplayMethod(id, name, salary);
					break;

				case 3:
					ExitMethod();
					break;
			}

		} while (choice != 3);
	}

	static void NewMethod(ref int id, ref string name, ref float salary)
	{
		Console.WriteLine("Enter Employee Data ");

		Console.Write("Enter Employee ID: ");
		id = int.Parse(Console.ReadLine());

		Console.Write("Enter Employee Name: ");
		name = Console.ReadLine();

		Console.Write("Enter Employee Salary: ");
		salary = float.Parse(Console.ReadLine());
	}

	static void DisplayMethod(int id, string name, float salary)
	{
		Console.WriteLine(" Employee Data ");
		Console.WriteLine("ID: " + id);
		Console.WriteLine("Name: " + name);
		Console.WriteLine("Salary: " + salary);
	}

	static void ExitMethod()
	{
		Console.WriteLine("Exiting the program. Goodbye!");
	}
}
