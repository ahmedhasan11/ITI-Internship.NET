namespace Seacrhing_Sorting_Menu_Program
{
    internal class Program
    {
        //public static Employee employee;
		public static List<Employee> Employees = new List<Employee>();
		static void Main(string[] args)
        {
			string[] Menu = { "New", "Display", "Exit", "Search_Emp-ByID","Search_Emp-ByName", "Sort with ID ", "Sort by Name", "Sort by Salary" };
			int digit = 0;
			bool looping = true;
			while (looping)
			{
				Console.Clear();
				int xPosition = Console.WindowWidth / 2 - 10;
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
					Console.SetCursorPosition(xPosition, yPosition + i*2);
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
								DisplayAllEmployees(Employees);
								Console.ReadKey(true);
								break;
							case 2:
								ExitMethod();
								looping = false;
								break;
							case 3:
								Employee.Search_Employee_By_ID(Employees);
								Console.ReadKey();
								break;
							case 4:
								Employee.Search_Employee_By_Name(Employees);
								Console.ReadKey();
								break;
							case 5:
								Employees.Sort(new Sort_By_ID());
								Program.DisplayAllEmployees(Employees);
								Console.ReadKey(true);
								break;
							case 6:
								Employees.Sort(new Sort_By_Name());
								Program.DisplayAllEmployees(Employees);
								Console.ReadKey(true);
								break;
							case 7:
								Employees.Sort(new Sort_By_Salary());
								Program.DisplayAllEmployees(Employees);
								Console.ReadKey(true);
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



		public static void NewMethod(/*ref int id, ref string name, ref double salary, ref int age*/)
		{
			int id = 0;
			string name = "";
			double salary = 0;
			int age = 0;
			Console.WriteLine("Enter Employee Data ");

			try
			{
				Console.Write("Enter Employee ID: ");
				id = int.Parse(Console.ReadLine());

				Console.Write("Enter Employee Name: ");
				name = Console.ReadLine();

				Console.Write("Enter Employee Salary: ");
				salary = double.Parse(Console.ReadLine());

				Console.Write("Enter Employee Age: ");
				age = int.Parse(Console.ReadLine());

				Employees.Add(new Employee(id, name, salary, age));
			}
			catch (Exception ex)
			{
				Console.WriteLine($" error:{ex.Message}");
			}
			finally
			{
				Console.WriteLine("back to main screen");
			}


			

		}

		public static void DisplayAllEmployees(List<Employee> Emps)
		{
			foreach (var Emp in Emps)
			{
				Console.WriteLine($"Employee ID= {Emp.Employee_ID}");
				Console.WriteLine($"Employee name= {Emp.Employee_Name}");
				Console.WriteLine($"Employee Salary= {Emp.Salary}");
				Console.WriteLine($"Employee Age= {Emp.Age}");
				Console.WriteLine("*************************************************************************");
			}
		}
		static void ExitMethod()
		{
			Console.WriteLine("Exiting the program. Goodbye!");
		}
	}
    }

