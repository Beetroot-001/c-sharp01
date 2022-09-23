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
			DisplayArray(myArr);

			Console.WriteLine();
			Console.WriteLine("Sorted random values array by Asc");

			DisplayArray(Sort(ref myArr, SortAlgorithmType.InsertionSort, OrderBy.Asc));
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Sorted random values array by Desc");
			DisplayArray(Sort(ref myArr, SortAlgorithmType.InsertionSort, OrderBy.Desc));
			Console.WriteLine();
			Console.WriteLine();

		}

		public static int[] SelectionSort(int[] array, OrderBy orderBy)
		{
			if (orderBy == OrderBy.Asc)
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
			else
			{
				for (int i = 0; i < array.Length - 1; i++)
				{
					int maxValue = i;
					for (int j = i + 1; j < array.Length; j++)
					{
						if (array[j] > array[maxValue])
						{
							maxValue = j;
						}
					}

					int temp = array[maxValue];
					array[maxValue] = array[i];
					array[i] = temp;
				}
				return array;
			}


		}
		public static int[] BubbleSort(int[] array, OrderBy orderBy)
		{

			if(orderBy == OrderBy.Asc)
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
			else
			{
				for (var i = 0; i <= array.Length - 2; i++)
				{
					for (var j = 0; j <= array.Length - 2; j++)
					{
						if (array[j] < array[j + 1])
						{
							int temp = array[j + 1];
							array[j + 1] = array[j];
							array[j] = temp;
						}
					}
				}
				return array;
			}
		}
		public static int[] InsertionSort(int[] array, OrderBy orderBy)
		{
			if (orderBy == OrderBy.Asc)
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
			else
			{
				for (int i = 1; i < array.Length; i++)
				{

					int key = array[i];
					int k = i - 1;

					while (k >= 0 && array[k] < key)
					{
						array[k + 1] = array[k];
						k--;
					}
					array[k + 1] = key;
				}
				return array;
			}

		}
		public static int[] Sort(ref int[] array, SortAlgorithmType sortType, OrderBy orderBy)
		{
			switch (sortType)
			{
				case SortAlgorithmType.SelectionSort:
					return SelectionSort(array, orderBy);
				case SortAlgorithmType.BubbleSort:
					return BubbleSort(array, orderBy);
				case SortAlgorithmType.InsertionSort:
					return InsertionSort(array, orderBy);
				default:
					throw new Exception("wrong sort type");
					
			}


		}
		public static void DisplayArray(int[] array)
		{
			Console.WriteLine(String.Join(", ", array));
		}
	}

}