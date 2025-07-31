using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Dimension_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number of integres");
            int n = int.Parse(Console.ReadLine());   
            int [] arr = new int [n];
			Console.WriteLine("enter numbers");
			int sum = 0;
            int max = arr[0];
            int min = arr[0];
			for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                sum += arr[i];
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }

            }
            float Average = sum / n;
            Console.WriteLine("sum = " + sum);
            Console.WriteLine("Average= "+ Average);

        }
    }
}
