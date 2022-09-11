namespace Lesson5_HomeWork_Extr_SupExtra_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 25;
            int b = 13;
            double c = 7.5;
            long d = 11;
            string str = "str";
            var maxVal1 = MaxValue(a, b);
            var maxVal2 = MaxValue(a, c);
            var minValue1 = MinValue(d, a);
            var minValue2 = MinValue(a, b, c, d);
            Console.WriteLine($"result MaxValue: {maxVal1} {maxVal2}");
            Console.WriteLine($"result MinValue: {minValue1} {minValue2}");

            int summ;
            bool bRef = false;
            bool result = TrySumIfOdd(a, b, out summ);
            TrySumIfOdd(a, b, str, ref bRef);
            Console.WriteLine("sum of numbers between par1 & par2: " + summ);
            Console.WriteLine(result);
            Console.WriteLine(bRef);

            int a2 = 3;
            var result4 = Str(str, a2);
            Console.WriteLine(result4);

            // Prints a square & cross figure
            for (long i = 0; i <= a; i++)
            {
                Console.Write(Fibo(i) + " ");
            }
            int horiz = 10;
            long vert = 10;
            PrintsSquareAndCrossFigure(horiz);
            PrintsSquareAndCrossFigure(vert);

            // Methods
        }
        static void PrintsSquareAndCrossFigure(int horizValue) // ▯
        {
            Console.WriteLine("\n");
            for (int i = 0; i < horizValue; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 || i == horizValue - 1) Console.Write("*");
                    else if (j == 0 || j == 10 - 1) Console.Write("*");
                    else Console.Write(" ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        static void PrintsSquareAndCrossFigure(long vertValue) // X
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < vertValue; j++)
                {
                    if (i == j || j == 10 - i - 1) Console.Write("*");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static long Fibo(long n) // Fibonacci number -  F(n)=F(n-1)+F(n-2)
        {
            if (n <= 1) return 1;
            else return Fibo(n - 2) + Fibo(n - 1);
        }


        static string Str(string str, int a) // Print Str 3x
        {
            string result = "";
            for (int i = 0; i < a; i++)
                result += str;
            return result;
        }


        static int MaxValue(int a, int b) // Overload maxVal
        {
            return (a > b) ? a : b;
        }
        static double MaxValue(int a, double c) // Overload maxVal
        {
            return (a > c) ? a : c;
        }
        static long MinValue(long d, int a) // Overload minVal
        {
            return Math.Min(a, d);
        }
        static double MinValue(int a, int b, double c, long d) // Overload minVal
        {
            var result1 = Math.Min(a, d);
            var result2 = Math.Min(c, d);
            return (result1 > result2) ? result2 : result1;
        }

        // Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd
        // otherwise false, sum return as out parameter
        static bool TrySumIfOdd(int a, int b, out int summ)
        {
            summ = 0;
            if (a < b)
            {
                for (int i = a; i <= b; i++) summ += i;
            }
            else if (a > b)
            {
                for (int i = b; i <= a; i++) summ += i;
            }
            else Console.WriteLine("par1 == par2");
            if (summ % 2 == 0) return true;
            else return false;
        }
        static void TrySumIfOdd(int a, int b, string str, ref bool bRef)
        {
            int summ = 0;
            if (a < b)
            {
                for (int i = a; i <= b; i++) summ += i;
            }
            else if (a > b)
            {
                for (int i = b; i <= a; i++) summ += i;
            }
            else Console.WriteLine("par1 == par2");
            Console.WriteLine(summ);
            if (summ % 2 == 0) bRef = true;
            else bRef = false;
        }
    }
}