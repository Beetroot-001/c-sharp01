using System.Text;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a = 3, b = 2, c = 6, d = 1;
			Console.WriteLine(max(a, b));
			Console.WriteLine(max(a, b, c));
			Console.WriteLine(max(a, b, c, d));

			Console.WriteLine(min(a, b));
			Console.WriteLine(min(a, b, c));
			Console.WriteLine(min(a, b, c, d));

			int sum;
            Console.WriteLine("? = "+ TrySumIfOdd( a, d,out sum) + "  Sum - "+ sum);

			string x = "**// ";
			Repeat(ref x, 5);
			Console.WriteLine("Extra1 - Repeat - " + x);
			Console.WriteLine("SExtra1 - Draw Square\n" + DrawSquare(4));
			Console.WriteLine("SExtra2 - Draw X\n" + DrawX(41));

		}

		static int max(int a, int b)
        {
			return Math.Max(a, b);
        }
		static int max(int a, int b, int c)
		{
			return max(Math.Max(a, b), c);
		}
		static int max(int a, int b, int c, int d)
		{
			return max(Math.Max(Math.Max(a, b), c), d);
		}
		static int maxOver(int a, int b, int c, params int[] values)
		{
			return max(Math.Max(Math.Max(a, b), c), values[0]);
		}

		static int min(int a, int b)
		{
			return Math.Min(a, b);
		}
		static int min(int a, int b, int c)
		{
			return min(min(a, b), c);
		}
		static int min(int a, int b, int c, int d)
		{
			return min(min(min(a, b), c), d);
		}


		static bool TrySumIfOdd(int a, int b, out int sum)
        {
			sum = a + b;
			return sum % 2 != 0;
        }

		static void Repeat(ref string x, int n)
		{
			x = string.Concat(Enumerable.Repeat(x, n));
		}

		static void Repeat(ref string x, int n, string? separator )
        {
			x = string.Join(separator,Enumerable.Repeat(x, n));
		}

		static string DrawSquare(int n)
        {
			string tb = "************";
			string side = "*          *";
			Repeat(ref side, n, "\n");

			return string.Join("\n", tb, side, tb);
        }
		
		static string DrawX(int n)
        {
			StringBuilder res = new();
			int l = (n % 2 == 0 ? n : n+1);
			string bs = " ";
			Repeat(ref bs, l);
			bs += "\n";

			for (int i = 0; i < l; i++)
			{
				
				char[] line = bs.ToCharArray();
				line[i] = '*';
				line[(l-1)-i] = '*';
				res.Append(string.Concat(line));
			}

			return res.ToString();
        }
	}
}