using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_simple_menu
{
    class Program
    {
        static void Main(string[] args)
        {
			int firstnumber, secondnumber;
			Console.WriteLine("enter first number");
			firstnumber=int.Parse(Console.ReadLine());
			Console.WriteLine("enter second number");
			secondnumber=int.Parse(Console.ReadLine());
			Console.WriteLine("1-calculate sum");
			Console.WriteLine("2-get max");
			Console.WriteLine("3-get min");
			string option = Console.ReadLine();
			switch (option)
			{
				case "1":
					Console.WriteLine(firstnumber+secondnumber);
					break;

				case "2":
					if (firstnumber > secondnumber) 
					{
						Console.WriteLine(firstnumber);
					}
					else if (secondnumber > firstnumber)
					{
						Console.WriteLine(secondnumber);
					}
					else
					{
						Console.WriteLine("they are equal");							
					}

						break;

				case "3":
					if (firstnumber < secondnumber)
					{
						Console.WriteLine(firstnumber);
					}
					else if (secondnumber < firstnumber)
					{
						Console.WriteLine(secondnumber);
					}
					else
					{
						Console.WriteLine("they are equal");
					}
					break;
					}




			Console.ReadKey();
		}
    }
}
