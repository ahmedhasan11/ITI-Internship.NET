namespace Generic_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
			//Console.Write("Enter the size of the stack: ");
			//int size = int.Parse(Console.ReadLine());

			Stacks <int> intstack = new Stacks<int>(5);
			Stacks<string> stringstack = new Stacks<string>(5);
			intstack.Push(10);
			intstack.Push(20);
			intstack.Display();
			intstack.Pop();

			stringstack.Push("Hello");
			stringstack.Push("World");
			stringstack.Display();
			stringstack.Pop();

			//while (true)
			//{
			//	Console.WriteLine(" Enter (PUSH)");
			//	Console.WriteLine(" Enter (POP)");
			//	Console.WriteLine(" Enter (DISPLAY)");
			//	Console.WriteLine(" Enter (EXIT)");
			//	Console.Write("\nEnter  ");

			//	string choice = Console.ReadLine().ToUpper();

			//	switch (choice)
			//	{
			//		case "PUSH":
			//			Console.Write("Enter value to push: ");
			//			int value = int.Parse(Console.ReadLine());
			//			stack.Push(value);
			//			break;

			//		case "POP":
			//			stack.Pop();
			//			break;

			//		case "DISPLAY":
			//			stack.Display();
			//			break;

			//		case "EXIT":
			//			Console.WriteLine("Exiting program...");
			//			return;

			//		default:
			//			Console.WriteLine("Invalid choice. Try again.");
			//			break;
			//	}

			Console.WriteLine("\nPress any key to continue...");
				Console.ReadKey();
				Console.Clear(); // Like your friend's screen
			}
		}
    }

