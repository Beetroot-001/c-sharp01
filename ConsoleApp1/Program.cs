using System;

namespace ConsoleApp1
{
	enum Status : short
	{
		NotStarted = 1,
		InProgress = 2,
		Completed = 4,
		Opened = 8,
		InProgresAndOpenet
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			int[] ints = new int[5];
			int[] ints2 = new int[5];

			int[] ints3 = new[] { 1, 2, 3 };
			int[] ints4 = { 1, 2, 3 };
			object[] ints5 = { 1, "2", new Program(), new[] { 1, 2 } };

			Console.WriteLine(ints == ints2);

			//Console.WriteLine(ints[-5]); error

			for (int i = 0; i < ints.Length; i++)
			{
				ints[i] = i + 1;
			}

			for (int i = 0; i < ints.Length; i++)
			{
				Console.Write($"{ints[i]} ,");
			}

			Console.WriteLine();

			int[] resMulBy = MulBy(ref ints, 2);

			for (int i = 0; i < ints.Length; i++)
			{
				Console.Write($"{ints[i]} ,");
			}
			Console.WriteLine();

			for (int i = 0; i < ints5.Length; i++)
			{
				var el = ints5[i];
			}

			Console.WriteLine($"Array - {ints}, ResArray - {resMulBy}, equals {resMulBy == ints}");


			int[,] ints6 = new int[4, 4];

			int[,] ints7 = new[,]
			{
				{ 1,1,1},
				{ 2,2,2},
				{ 3,3,3 }
			};
			int[,] ints8 = {
				{ 1,1,1 },
				{ 2,2,2 },
				{ 3,3,3 }
			};

			for (int i = 0; i < ints8.GetLength(0); i++)
			{
				for (int j = 0; j < ints8.GetLength(1); j++)
				{
					Console.Write($"{ints8[i, j]}, ");
				}
				Console.WriteLine();
			}

			Console.WriteLine();
			Console.WriteLine("------jugged array------");

			int[][] ints9 = new int[3][];
			ints9[0] = new int[3];
			ints9[0][0] = 1;
			ints9[0][1] = 2;
			ints9[0][2] = 3;

			ints9[1] = new int[1];
			ints9[1][0] = 4;

			ints9[2] = new int[2];
			ints9[2][0] = 5;
			ints9[2][1] = 6;

			for (int i = 0; i < ints9.Length; i++)
			{

				for (int j = 0; j < ints9[i].Length; j++)
				{
					Console.Write($"{ints9[i][j]}, ");
				}
				Console.WriteLine();
			}

			int[][][] ints10 = new int[10][][];

			Console.WriteLine("----Foreach---");
			foreach (int element in ints3)
			{
				Console.WriteLine(element);
			}
			Console.WriteLine("--multidementional array--");
			foreach (int element in ints7)
			{
				Console.Write(element);
			}

			Console.WriteLine("--copy array--");
			int[] sourceArray = { 1, 1, 2, 3, 4, 5, 6 };
			int[] arrayCopy = CopyArray(sourceArray);

			int[] array11 = new int[5] { 1, 2, 3, 4, 5 };
			PrintArray(array11);
			var newArray2 = AddElement(array11);
			PrintArray(newArray2);

			Console.WriteLine("Reverse");
			PrintArray(array11);

			var newArray3 = Reverse(array11);
			PrintArray(newArray3);

			Console.WriteLine("--FindMinMax---");
			FindMinMax(new[] { 7, 2, 1, 3, 3, 7, 8, 2 }, out int min, out int max);
			Console.WriteLine($"Min: {min}");
			Console.WriteLine($"Max: {max}");



			Status opened = Status.Opened;
			Method(Status.Opened);
			Method(Status.InProgress);
			Method(Status.Completed);

			var res = (Status)Enum.Parse(typeof(Status), "10");
		}

		public static void Method(Status a)
		{
			//if (a == Status.InProgresAndOpened)
			//{
			//	Console.WriteLine("InProgress or Opened");
			//}

			switch (a)
			{
				case Status.NotStarted:
					break;
				case Status.InProgress:
					break;
				case Status.Completed:
					break;
				case Status.Opened:
					break;
				default:
					break;
			}
		}

		public static int[] MulBy(ref int[] array, int n)
		{
			array = new int[5];

			for (int i = 0; i < array.Length; i++)
			{
				array[i] += n;
			}

			return array;
		}

		public static int[] CopyArray(int[] sourceArray)
		{
			int[] newArray = new int[sourceArray.Length];

			for (int i = 0; i < sourceArray.Length; i++)
			{
				newArray[i] = sourceArray[i];
			}

			return newArray;
		}


		public static int[] AddElement(int[] sourceArray)
		{
			int number = 10;
			int[] newArray = new int[sourceArray.Length + 1];

			newArray[0] = number;

			//for (int i = 1; i <= newArray.Length; i++)
			//{
			//	newArray[i] = sourceArray[i - 1];
			//}

			for (int i = 0; i < sourceArray.Length; i++)
			{
				newArray[i + 1] = sourceArray[i];
			}

			return newArray;
		}


		static void PrintArray(int[] array)
		{
			foreach (int element in array)
			{
				Console.Write($"{element}, ");
			}

			Console.WriteLine();
		}

		static int[] Reverse(int[] sourceArray)
		{
			// do magic
			int[] newArray = new int[sourceArray.Length];

			for (int i = 0; i < sourceArray.Length; i++)
			{
				newArray[i] = sourceArray[sourceArray.Length - i - 1];
			}

			return newArray;
		}

		static void FindMinMax(int[] sourceArray, out int min, out int max)
		{
			for (int i = 0; i < sourceArray.Length; i++)
			{
				for (int j = 0; j < sourceArray.Length - 1 - i; j++)
				{
					if (sourceArray[j] > sourceArray[j + 1])
					{
						int temp = sourceArray[j];
						sourceArray[j] = sourceArray[j + 1];
						sourceArray[j + 1] = temp;
					}
				}
			}

			min = sourceArray[0];
			max = sourceArray[sourceArray.Length - 1];
		}
	}
}