namespace ConsoleApp1
{
	internal class Program
	{
		public enum SortAlgorithmType
		{
			SelectionSort,
			BubbleSort,
			InsertionSort
		}

		public enum OrderBy
		{
			Asc,
			Desc
		}

		static void Main(string[] args)
		{
			Random random = new Random();
			int length1 = random.Next(5,10);
			int[] myArr = new int[length1];

			for (int i = 0; i < length1 - 1; i++)
			{
				myArr[i] = random.Next(100);
			}
			Console.WriteLine("RANDOM VALUES ARRAY");
			foreach (var item in myArr)
			{
				if (myArr.Length - 1 == Array.LastIndexOf(myArr, item))
				{
					Console.Write($"{item} ");
				}
				else
				{
					Console.Write($"{item}, ");
				}
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Sorted random values array by Asc");

			Sort(ref myArr, SortAlgorithmType.InsertionSort, OrderBy.Asc);
			foreach (var item in myArr)
			{
				if (myArr.Length - 1 == Array.LastIndexOf(myArr, item))
				{
					Console.Write($"{item} ");
				}
				else
				{
					Console.Write($"{item}, ");
				}
			}
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Sorted random values array by Desc");
			Sort(ref myArr, SortAlgorithmType.SelectionSort, OrderBy.Desc);
			for (int i = 0; i < myArr.Length; i++)
			{
				if (i == myArr.Length - 1)
				{
					Console.Write($"{myArr[i]} ");
				}
				else
				{
					Console.Write($"{myArr[i]}, ");
				}
			}
			Console.WriteLine();
			Console.WriteLine();

		}

		public static int[] SelectionSort(int[] array)
		{

			for (int i = 0; i < array.Length - 1; i++)
			{
				int minValue = i;
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[j] < array[minValue])
					{
						minValue = j;
					}
				}

				int temp = array[minValue];
				array[minValue] = array[i];
				array[i] = temp;
			}
			return array;
		}
		public static int[] BubbleSort(int[] array)
		{

			for (var i = 0; i <= array.Length - 2; i++)
			{
				for (var j = 0; j <= array.Length - 2; j++)
				{
					if (array[j] > array[j + 1])
					{
						int temp = array[j + 1];
						array[j + 1] = array[j];
						array[j] = temp;
					}
				}
			}
			return array;
		}
		public static int[] InsertionSort(int[] array)
		{

			for (int i = 1; i < array.Length; i++)
			{

				int key = array[i];
				int k = i - 1;

				while (k >= 0 && array[k] > key)
				{
					array[k + 1] = array[k];
					k--;
				}
				array[k + 1] = key;
			}
			return array;
		}

		public static int[] Reverse(int[] array)
		{
			int[] outArray = new int[array.Length];
			for (int i = 0;i < array.Length; i++)
			{
				outArray[i] = array[array.Length - i - 1];
			}
			return outArray;
		}
		public static void Sort(ref int[] array, SortAlgorithmType sortType, OrderBy orderBy)
		{
			switch (sortType)
			{
				case SortAlgorithmType.SelectionSort:
					SelectionSort(array);
					break;
				case SortAlgorithmType.BubbleSort:
					BubbleSort(array);
					break;
				case SortAlgorithmType.InsertionSort:
					InsertionSort(array);
					break;
				default:
					break;
			}

			if (orderBy == OrderBy.Asc)
			{
				array = array;
			}
			else
			{
				array = Reverse(array);
			}
		}
	}

}