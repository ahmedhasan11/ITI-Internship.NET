namespace Bubble_Sort_implementation
{
	internal class Program
	{
		public delegate bool Compare(int L, int M);

		static void Main(string[] args)
		{		
			int[] arrayofintegers = { 69, 78, 22, 33 };
			bubbleSort(arrayofintegers, sortAscending); 
			foreach (var integer in arrayofintegers)
			{
				Console.WriteLine(integer);
			}
		}
		public static void bubbleSort(int[] arr, Compare compare)
		{
			for (int j = 0; j < arr.Length; j++)
			{
				for (int i = 0; i < arr.Length - 1 - j; i++)
				{
					if (compare(arr[i], arr[i + 1]))
					{
						Swap(ref arr[i], ref arr[i + 1]);
					}
				}
			}
		}
		static bool sortAscending(int L, int M)
		{
			return (L > M);
		}

		static bool sortDecending(int L, int M)
		{
			return (L < M);
		}

		public static void Swap(ref int L, ref int M)
		{

			int tempvar = L;
			L = M;
			M = tempvar;
		}

		/*  Console.Write("Enter the number of elements: ");
            int size = int.Parse(Console.ReadLine());

            int[] arrayofintegers = new int[size];

            Console.WriteLine("Enter the elements:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element [{i}]: ");
                arrayofintegers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("enter choice");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                bubbleSort(arrayofintegers, sortAscending);
            else if (choice == 2)
                bubbleSort(arrayofintegers, sortDecending);*/



		//public static void BubbleSort(int[]arr)
		//{
		//    for(int i=0; i < arr.Length - 1; i++)
		//    {
		//        for (int j=0; j<arr.Length-1-i;j++)
		//        {
		//            if (sortDecending(arr[i], arr[i+1]))
		//            {
		//                Swap(ref arr[i], ref arr[i + 1]);
		//            }
		//        }
		//    }
		//}

		//public static void BubbleSortAscending(int[] arr)
		//{
		//	for (int i = 0; i < arr.Length - 1; i++)
		//	{
		//		for (int j = 0; j < arr.Length - 1 - i; j++)
		//		{
		//			if (sortAscending(arr[j], arr[j + 1]))
		//			{
		//				Swap(ref arr[j], ref arr[j + 1]);
		//			}
		//		}
		//	}
		//}
		//public static void BubbleSortDecsending(int[] arr)
		//{
		//	for (int i = 0; i < arr.Length - 1; i++)
		//	{
		//		for (int j = 0; j < arr.Length - 1 - i; j++)
		//		{
		//			if (sortDecending(arr[j], arr[j + 1]))
		//			{
		//				Swap(ref arr[j], ref arr[j + 1]);
		//			}
		//		}
		//	}
		//}

	}

}

