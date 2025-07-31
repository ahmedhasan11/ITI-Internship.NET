using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Array_assgignment
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("enter number of class rooms");

            int classrooms = int.Parse(Console.ReadLine());

			int[][] Marks = new int[classrooms][];

			for (int i = 0; i < classrooms; i++)
			{
				Console.WriteLine($"enter number of student in classroom {i+1}");
				int students = int.Parse(Console.ReadLine());
				Marks[i] = new int[students];
				for (int j = 0; j < students; j++)
				{
					Console.WriteLine($"\nEnter marks for {students} students in classroom {i + 1}:");
					Marks[i][j] = int.Parse(Console.ReadLine());

				}

			}
			for (int i = 0; i < classrooms; i++)
			{
				int sum = 0;
				for (int j = 0; j < Marks[i].Length; j++)
				{
					sum += Marks[i][j];

				}

				double average = sum / (double)Marks[i].Length;
				Console.WriteLine($"Classroom {i + 1}: {average:0.00}");
			}

		}
    }
}
