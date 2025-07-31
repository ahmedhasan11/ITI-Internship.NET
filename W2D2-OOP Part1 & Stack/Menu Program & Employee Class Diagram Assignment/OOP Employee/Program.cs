using OOP_Employee;
using System;
using System.Xml.Linq;

class Program
{
	static Employee employee;

	static void Main()
	{
		string[] Menu = { "New", "Display", "Exit" };
		int digit = 0;
		bool looping = true;
		while (looping)
		{
			Console.Clear();
			int xPosition = Console.WindowWidth / 2;
			int yPosition = Console.WindowHeight / 4;
			for (int i = 0; i < Menu.Length; i++)
			{
				if (i == digit)
				{
					Console.BackgroundColor = ConsoleColor.Blue;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.White;
				}
				Console.SetCursorPosition(xPosition, yPosition * (i + 1));
				Console.Write(Menu[i]);
				Console.ResetColor();
			}
			ConsoleKeyInfo consoleKey = Console.ReadKey(true);
			switch (consoleKey.Key)
			{
				case ConsoleKey.UpArrow:
					if (digit == 0)
					{
						digit = Menu.Length - 1;
					}
					else
					{
						digit = digit - 1;
					}
					break;
				case ConsoleKey.DownArrow:
					if (digit == Menu.Length - 1)
					{
						digit = 0;
					}
					else
					{
						digit = digit + 1;
					}
					break;
				case ConsoleKey.Enter:
					Console.Clear();
					switch (digit)
					{
						case 0:
							NewMethod();
							break;
						case 1:
							employee.DisplayMethod();
							Console.ReadKey(true);
							break;
						case 2:
							ExitMethod();
							looping = false;
							break;
					}
					break;
			}
		}
	}
		//int id = 0;
		//string name = "";
		//double salary = 0;
		//int age = 0;
		bool dataEntered = false;

		

	static void NewMethod(/*ref int id, ref string name, ref double salary, ref int age*/)
	{

		Console.WriteLine("Enter Employee Data ");

		Console.Write("Enter Employee ID: ");
		int id = int.Parse(Console.ReadLine());

		Console.Write("Enter Employee Name: ");
		string name = Console.ReadLine();

		Console.Write("Enter Employee Salary: ");
		double salary = double.Parse(Console.ReadLine());

		Console.Write("Enter Employee Age: ");
		int age = int.Parse(Console.ReadLine());
		employee = new Employee(id, name, salary, age);

	}
	static void ExitMethod()
	{
		Console.WriteLine("Exiting the program. Goodbye!");
	}
	//	int choice;

	//	do
	//	{
	//		Console.WriteLine(" Menu ");
	//		Console.WriteLine("1. New");
	//		Console.WriteLine("2. Display");
	//		Console.WriteLine("3. Exit");
	//		Console.Write("Enter choice : ");
	//		choice = int.Parse(Console.ReadLine());

	//		switch (choice)
	//		{
	//			case 1:
	//				NewMethod(/*ref id, ref name, ref salary, ref age*/);
	//				dataEntered = true;
	//				break;

	//			case 2:
	//				if (dataEntered)
	//					employee.DisplayMethod();
	//				break;

	//			case 3:
	//				ExitMethod();
	//				break;
	//		}

	//	} while (choice != 3);
	//}
  


	//static void DisplayMethod(int id, string name, double salary, int Age)
	//{
	//	Console.WriteLine(" Employee Data ");
	//	Console.WriteLine("ID: " + id);
	//	Console.WriteLine("Name: " + name);
	//	Console.WriteLine("Salary: " + salary);
	//}


}

