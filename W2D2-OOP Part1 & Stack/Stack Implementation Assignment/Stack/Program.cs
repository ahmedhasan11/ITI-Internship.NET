using System;

class Program
{
	static void Main()
	{
		Console.Write("Enter the size of the stack: ");
		int size = int.Parse(Console.ReadLine());

		Stacks stack = new Stacks(size);

		while (true)
		{
			Console.WriteLine(" Enter (PUSH)");
			Console.WriteLine(" Enter (POP)");
			Console.WriteLine(" Enter (DISPLAY)");
			Console.WriteLine(" Enter (EXIT)");
			Console.Write("\nEnter  ");

			string choice = Console.ReadLine().ToUpper();

			switch (choice)
			{
				case "PUSH":
					Console.Write("Enter value to push: ");
					int value = int.Parse(Console.ReadLine());
					stack.Push(value);
					break;

				case "POP":
					stack.Pop();
					break;

				case "DISPLAY":
					stack.Display();
					break;

				case "EXIT":
					Console.WriteLine("Exiting program...");
					return;

				default:
					Console.WriteLine("Invalid choice. Try again.");
					break;
			}

			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
			Console.Clear(); // Like your friend's screen
		}
	}
}

