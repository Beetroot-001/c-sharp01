namespace ConsoleApp1
{
	internal class Program
	{
		static int Max (int a,int b)
		{
			return a > b ? a : b;
		}
        static int Max(int a, int b,int c,int d)
        {
			int[] max = {a,b,c,d};
			int g = a;
			for (int i = 1; i < max.Length; i++)
			{
				if(max[i] > g)
					g = max[i];
			}
			return g;
        }
        static int Min(int a, int b)
        {
            return a > b ? b : a;
        }
        static int Min(int a, int b,int c,int d)
        {
            int[] min = { a, b, c, d };
            int g = a;
            for (int i = min.Length - 1; i > 0; i--)
            {
                if (min[i] < g)
                    g = min[i];
            }
            return g;
        }
        static bool TrySumIfOdd (int a, int b, out int Sum)
		{
			Sum = a + b;
			if (Sum % 2 == 0)
			{
                Sum = a + b;
                return false;
			}
			return true;
		}


        static void Main(string[] args)
		{
			int a = 6;
			int b = 22;
			int c = -7;
			int d = 8;	
			int Sum = 0;
			string str = "ga";
			Console.WriteLine(Max(a, b));
			Console.WriteLine($"Max four shifts {Max(a, b, c, d)}");
            Console.WriteLine(Min(a, b));
			Console.WriteLine($"Min four shifts {Min(a, b, c, d)}");
			Console.WriteLine(TrySumIfOdd (a, b, out Sum)); 
			Console.WriteLine($"Sum a and b {Sum}");


            Console.ReadLine();
		}
	}
} 