namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test case 1: 3, 5, 7");
            Console.WriteLine("Max: " + MaxVal(3, 5, 7));
            Console.WriteLine("Min: " + MinVal(3, 5, 7));

            Console.WriteLine("test case 2: 7, 5, 3");
            Console.WriteLine("Max: " + MaxVal(7, 5, 3));
            Console.WriteLine("Min: " + MinVal(7, 5, 3));
            Console.WriteLine("test case 3: 4, 8, 6");
            Console.WriteLine("Max: " + MaxVal(4, 8, 6));
            Console.WriteLine("Min: " + MinVal(4, 8, 6));
            bool result = false;
            Console.WriteLine("3+5= Odd:");
            Console.WriteLine(TrySumIfOdd(3, 5, out result));
            Console.WriteLine("2+3 = Odd:");
            Console.WriteLine(TrySumIfOdd(2, 3, out result));

            Console.WriteLine("Min Val amongst 3.14, 3.15, 3.16, 3.17 = ");
            Console.WriteLine(MinVal(3.14, 3.15, 3.16, 3.17));

            Console.WriteLine("Max Val amongst 3.14, 3.15, 3.16, 3.17 = ");
            Console.WriteLine(MaxVal(3.14, 3.15, 3.16, 3.17));

            Console.Write("str x3: ");
            Repeat("str", 3);
            Console.WriteLine();
            Console.Write("Fibonacci sequence of 15: ");
            FiboNum(15);
            DrawSqr();
        }
        static int MaxVal(int a, int b, int c)
        {
            int max = Math.Max(a, b);
            int trueMax = Math.Max(max, c);

            return trueMax;
        }

        static int MinVal(int a, int b, int c)
        {
            int min = Math.Min(a, b);
            int trueMin = Math.Min(min, c);

            return trueMin;
        }

        static double MinVal(double a, double b, double c, double d)
        {
            double min = Math.Min(a, b);
            double trueMin = Math.Min(min, c);
            double truetrueMin = Math.Min(min, d);

            return truetrueMin;
        }
        static double MaxVal(double a, double b, double c, double d)
        {
            double min = Math.Max(a, b);
            double trueMax = Math.Max(min, c);
            double truetrueMax = Math.Max(min, d);

            return truetrueMax;
        }
        static bool TrySumIfOdd(int a, int b, out bool isOdd)
        {
            isOdd = (a + b) % 2 == 0 ? true : false;
            return isOdd;

        }
        static void Repeat(string str, int x)
        {
            for (int i = 0; i < x; i++)
                Console.Write(str);
        }
        static void FiboNum(int x)
        {
            int x1 = 0;
            int x2 = 1;


            for (int i = 0; i < x; i++)
            {
                int fibb = x1;
                x1 = x2;
                x2 = fibb + x2;
                Console.Write(fibb + " ");

            }



        }
        static void DrawSqr(int n = 10)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == n-1 || i == 0|| j == n-1 || j == 0 || j == n-1)
                    Console.Write('*');
                    else Console.Write(' ');
                }
                Console.WriteLine();

            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || n - 1 - i == j)
                        Console.Write('*');
                    else Console.Write(' ');
                }
                Console.WriteLine();

            }
            Console.WriteLine();
            int halfOfN = n / 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == halfOfN || j == halfOfN)
                        Console.Write("*");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

    }
}