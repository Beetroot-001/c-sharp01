using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{	
    internal class Program
	{
        public enum SortAlgorithmType
        {
            Insertion,
			Selection,
			Bubble
        }

		public enum OrderBy
		{
			Ascending,
			Descending
		}
        static void Main(string[] args)
		{
			int[] t1 = new int[10];
			int[] t2 = new int[15];
			int[] t3 = new int[20];

			Randomise(t1, 0, 100);
			Randomise(t2, 0, 150);
			Randomise(t3, 0, 200);

            Sort(t1, SortAlgorithmType.Insertion, OrderBy.Ascending);
            Randomise(t1, 0, 100);
            Sort(t1, SortAlgorithmType.Insertion, OrderBy.Descending);
            Sort(t2, SortAlgorithmType.Bubble, OrderBy.Ascending);
            Randomise(t2, 0, 150);
            Sort(t2, SortAlgorithmType.Bubble, OrderBy.Descending);
            Sort(t3, SortAlgorithmType.Selection, OrderBy.Ascending);
            Randomise(t3, 0, 200);
            Sort(t3, SortAlgorithmType.Selection, OrderBy.Descending);
        }

        public static void PrintArray(int[] array)
		{
			foreach (int i in array)
			{
				Console.Write($"{i} ");
			}
			Console.WriteLine();
		}
		public static void Randomise(int[] array, int min, int max)
		{	
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next(min, max);
			}
		}

		public static void Sort(int[] array, SortAlgorithmType type, OrderBy order)
		{
			Console.WriteLine("Array before soring: ");
            PrintArray(array);
            switch (type)
			{
				case SortAlgorithmType.Insertion:
					Console.WriteLine("Insertion sort");
                    InsertionSort(array);
					break;
				case SortAlgorithmType.Selection:
					Console.WriteLine("Selection sort");
					SelectionSort(array);
					break;
				case SortAlgorithmType.Bubble:
					Console.WriteLine("Bubble sort");
                    BubbleSort(array);
                    break;
				default:
					break;
			}
			if(order == OrderBy.Descending)
			{
				Console.WriteLine("In descending");
				Reverse(ref array);
			}
            Console.WriteLine("Array after soring: ");
            PrintArray(array);
        }

		public static void Reverse(ref int[] array)
		{
            int[] reversed = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reversed[i] = array[array.Length - i - 1];
            }
            array = reversed;
        }
		public static void BubbleSort(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length - 1; j++)
				{
					if (array[j] > array[j+1])
					{
						int t = array[j];
						array[j] = array[j+1];
						array[j + 1] = t;
					}
				}
			}
		}

		public static void SelectionSort(int[] array)
		{
			int min;
			for (int i = 0; i < array.Length - 1; i++)
			{
				min = i;
				for (int j = i+1; j < array.Length; j++)
				{
					if (array[j] < array[min])
						min = j;
				}
				if (min != i)
				{
					int t = array[min];
					array[min] = array[i];
					array[i] = t;
				}
			}
		}

		public static void InsertionSort(int[] array)
		{
			int pos;
			int value;

			for (int i = 1; i < array.Length; i++)
			{
				value = array[i];
				pos = i;

				while (pos > 0 && array[pos - 1] > value)
				{
					array[pos] = array[pos - 1];
					pos = pos - 1;
				}
				array[pos] = value;
			}
		}
	}
}