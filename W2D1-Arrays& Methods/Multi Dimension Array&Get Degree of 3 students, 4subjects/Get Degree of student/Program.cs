using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Get_Degree_of_student
{
    class Program
    {
        static void Main(string[] args)
		{
			int[,] studentdegrees = new int[3, 4];

            //int [] sumforsubjects = new int;
            double[] averageforsubjects= new double[4];

            for(int i = 0; i < studentdegrees.GetLength(0); i++)
            {
				int sum = 0;
				Console.WriteLine("enter 4 degrees for the student split by spaces ");
				string[] degrees = Console.ReadLine().Split(' ');
				for (int j = 0; j < studentdegrees.GetLength(1); j++)
				{
					studentdegrees[i, j] = int.Parse(degrees[j]);
                    sum += studentdegrees[i, j];

				}
                Console.WriteLine(sum);
                Console.WriteLine();
            }
			for (int j = 0; j < studentdegrees.GetLength(1); j++)
			{
				int sumforsubjects=0;
				for (int i = 0; i < studentdegrees.GetLength(0); i++)
				{
					sumforsubjects += studentdegrees[i,j];	                                               			


				}
				averageforsubjects[j] = sumforsubjects / 3;
				//averageforsubjects = sumforsubjects / 4;
				//Console.WriteLine(averageforsubjects)				/* sumforsubjects / 4;*/

			}
			foreach (double subjectavg in averageforsubjects)
			{
				Console.WriteLine(subjectavg);
			}
		}
    }
}
