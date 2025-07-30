using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter first number");
            int firstnumber = int.Parse(Console.ReadLine());
			Console.WriteLine("enter second number");
			int secondnumber = int.Parse(Console.ReadLine());

            int sum = firstnumber + secondnumber;
            Console.WriteLine(sum);
            float Average = (sum / 2);
            Console.WriteLine(Average);
            Console.ReadKey();
		}
    }
}
