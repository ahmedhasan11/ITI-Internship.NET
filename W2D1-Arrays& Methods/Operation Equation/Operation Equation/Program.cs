using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation_Equation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the full equation");
			string equation = Console.ReadLine();
			int result = 0;
			if (equation.Contains("+"))
			{
				string[] parts = equation.Split('+');
				Console.WriteLine(result = int.Parse(parts[0]) + int.Parse(parts[1]));
			}
			else if (equation.Contains("*"))
			{
				string[] parts = equation.Split('*');
				Console.WriteLine(result = int.Parse(parts[0]) * int.Parse(parts[1]));
			}
			else if (equation.Contains("-"))
			{
				string[] parts = equation.Split('-');
				Console.WriteLine(result = int.Parse(parts[0]) - int.Parse(parts[1]));
			}
			else if (equation.Contains("/"))
			{
				string[] parts = equation.Split('/');
				Console.WriteLine(result = int.Parse(parts[0]) / int.Parse(parts[1]));
			}


































			//         int i = 3;
			//         char operators;

			//string[] equation = Console.ReadLine().Split(' ');

			//foreach (char op in equation)
			//         {
			//             if (op== '+' || op=='-' || op=='*' || op=='/')
			//             {
			//                 operators = op;

			//             }
			//         }

			//int num1 = int.Parse(equation[0]);
			//         int num2 = int.Parse(equation[1]);
			//         switch (operators)
			//         {
			//             case '+':
			//                 Console.WriteLine(num1+num2);
			//                 break;
			//	case '*':
			//		Console.WriteLine(num1 * num2);
			//		break;
			//	case '-':
			//		Console.WriteLine(num1 - num2);
			//		break;
			//	case '/':
			//		Console.WriteLine(num1 / num2);
			//		break;
			//}

		}
    }
}
