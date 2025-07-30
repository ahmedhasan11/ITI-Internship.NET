using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstnumber, secondnumber;

            string operatorused;
            Console.WriteLine("enter first number");
            firstnumber = int.Parse(Console.ReadLine());
			Console.WriteLine("enter second number");
			secondnumber = int.Parse(Console.ReadLine());
			Console.WriteLine("enter operator");
			operatorused = Console.ReadLine();
			switch (operatorused)
            {
                case "*" :
                    Console.WriteLine( firstnumber * secondnumber);
                        break;

                case "/":
					Console.WriteLine(firstnumber / secondnumber);
					break;

				case "+":
					Console.WriteLine(firstnumber + secondnumber);
					break;

				case "-":
					Console.WriteLine(firstnumber - secondnumber);
					break;

                default:
                    Console.WriteLine("invalid operator");
                    break;

			}



            
        }
    }
}
