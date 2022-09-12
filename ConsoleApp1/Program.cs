using System.Diagnostics;
using System.Security.Cryptography;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = 10;

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if(i == 0 || i == n - 1 || j == 0 || j == n - 1)
					{
						Console.Write('*');
					}
					else
					{
						Console.Write(' ');
					}
				}
				Console.WriteLine();
			}

			Console.WriteLine("---------------------");
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (i == j || n - 1 - i == j)
					{
						Console.Write('*');
					}
					else
					{
						Console.Write(' ');
					}
				}
				Console.WriteLine();
			}


			Random random = new Random((int)DateTime.Now.Ticks);
			var t = RandomNumberGenerator.GetInt32(0, 1);

			var t1 = 1;
			var t2 = 2;

			var t3 = t1 | t2;

			var random1 = random.Next();
			var random12 = random.Next();
			Console.WriteLine($"random.Next(): {random1}");
			Console.WriteLine($"random.Next(): {random12}");

			var random2 = random.Next(100);
			Console.WriteLine($"random.Next(100): {random2}");

			var random3 = random.Next(10, 20);
			Console.WriteLine($"random.Next(10, 20): {random3}");

			var random4 = random.NextDouble();
			Console.WriteLine($"random.NextDouble(): {random4}");


			var b = 6;
			var a = 5;

			double res1 = Sum(a, b);
			Console.WriteLine($"Res1 = {res1}");


			var c = 5.6;
			var d = 4.5;
			double res2 = Sum(c, d);
			Console.WriteLine($"Res2 = {res2}");

			string res = PrintStr("str", 10);

			{
				int g = 1;
			}
			Console.WriteLine(res);
		}

		public static double Sum(int a, int b)
		{
			int c = 9;

			return a + b;
		}

		public static double Sum(double a, double b)
		{
			return a + b;
		}

		public static string PrintStr(string stringToPrint, int nTimes)
		{
			Debug.WriteLineIf(nTimes % 2 == 0, $"DEBUG nTimes: {nTimes}");

			if (nTimes <= 1) return stringToPrint;
			var res = stringToPrint + PrintStr(stringToPrint, nTimes - 1);

			Console.WriteLine($"Hello {res} iteration: {nTimes}");

			return res;
		}
	}
}