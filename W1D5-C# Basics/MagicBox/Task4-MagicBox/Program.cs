using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_MagicBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the magic box");
            int n = int.Parse(Console.ReadLine());
            int row = 0;

            int column = 1;

            int number = 1;

            int spacing = 16;

            while (number <= n*n)
            {
                Console.SetCursorPosition(column * spacing, row+2);
                Console.Write(number);
                if (number % n == 0)
                {
                    row++;
                    
                }
                else if (number % n != 0)
                {
                    row--;
                    column--;
                }
                if (row < 0)
                {
                    row = n - 1;
                }

                if (column < 0) 
                {
                    column = n - 1;
                        
                }
                if (row >= n)
				{
                     row = 0;
                }
                if (column >= n)
                {
                    column = 0;
                }
				number++;
            }

			Console.ReadKey();
		}
    }
}
