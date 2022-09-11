using System.Runtime.InteropServices;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("--==Homework==--");
            Console.WriteLine("1, 2, 4 :");

            //int max
            Console.WriteLine($"int Max(5, 9): {Max(5, 9)}");
            Console.WriteLine($"int Max(5, 9, 3): {Max(5, 9, 3)}");
            Console.WriteLine($"int Max(1, 6, 2, 89, 193): {Max(1, 6, 2, 89, 193)}\n");
            //float max
            Console.WriteLine($"float Max(5.4f, 7.9f): {Max(5.4f, 7.9f)}");
            Console.WriteLine($"float Max(5.4f, 7.9f, 9.3f): {Max(5.4f, 7.9f, 9.3f)}");
            Console.WriteLine($"float Max(0.1f, 6.0f, 2.8f, 8.9f, 19.3f): {Max(0.1f, 6.0f, 2.8f, 8.9f, 19.3f)}\n");
            //int min
            Console.WriteLine($"int Min(5, 9): {Min(5, 9)}");
            Console.WriteLine($"int Min(5, 9, 3): {Min(5, 9, 3)}");
            Console.WriteLine($"int Min(1, 6, 2, 89, 193): {Min(1, 6, 2, 89, 193)}\n");
            //float min
            Console.WriteLine($"float Min(5.4f, 7.9f): {Min(5.4f, 7.9f)}");
            Console.WriteLine($"float Min(5.4f, 7.9f, 9.3f): {Min(5.4f, 7.9f, 9.3f)}");
            Console.WriteLine($"float Min(0.1f, 6.0f, 2.8f, 8.9f, 19.3f): {Min(0.1f, 6.0f, 2.8f, 8.9f, 19.3f)}\n");

            Console.WriteLine("3:");
            int sum;

            Console.WriteLine($"TrySumIfOdd(10, 3, out sum): {TrySumIfOdd(10, 3, out sum)}; sum = {sum}\n");

            Console.WriteLine("--==Extra 0==--");

            Console.Write("input string: ");
            string str = input_str() ?? " ";
            Console.Write("input repeat number: ");
            int n = input_int();
            Console.Write($"Repeat({str}, n): "); 
            Repeat(str, n);

            Console.WriteLine("\n--==Extra 1==--");

            Console.Write("input Fibonacci count: ");
            n = input_int();

            Console.Write($"Fibonacci_Loop({n}): ");
            Fibonacci_Loop(n);

            Console.Write($"Fibonacci_rec({n});  ");
            Fibonacci_rec(n);

            Console.WriteLine("\n--==Extra 2==--");

            Console.Write("input side length: ");
            n = input_int();

            OutSqare(n);
            Console.WriteLine();

            OutCross(n);
            Console.WriteLine();

            Console.Write("input circle radius: ");
            n = input_int();

            OutCircle(n);
        }

        static string? input_str()
        {
            return Console.ReadLine();
        }

        static int input_int()
        {
            string? input_string = Console.ReadLine();
            int res;

            while (!int.TryParse(input_string, out res))
            {
                Console.WriteLine("invalid input");
                input_string = Console.ReadLine();
            }
            return res;
        }

        static int Max(int a, int b)
        {
            if (a > b) return a;
            return b;
        }

        static int Max(int a, int b, int c)
        {
            if (a > b && a > c) return a;
            
            if (b > a && b > c) return b;

            return c;
        }

        static int Max(params int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }
        static float Max(float a, float b)
        {
            if (a > b) return a;
            return b;
        }

        static float Max(float a, float b, float c)
        {
            if (a > b && a > c) return a;

            if (b > a && b > c) return b;

            return c;
        }

        static float Max(params float[] arr)
        {
            float max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }

        static int Min(int a, int b)
        {
            if (a < b) return a;
            return b;
        }

        static int Min(int a, int b, int c)
        {
            if (a < b && a < c) return a;

            if (b < a && b < c) return b;

            return c;
        }

        static int Min(params int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
            }
            return min;
        }
        
        static float Min(float a, float b)
        {
            if (a < b) return a;
            return b;
        }

        static float Min(float a, float b, float c)
        {
            if (a < b && a < c) return a;

            if (b < a && b < c) return b;

            return c;
        }

        static float Min(params float[] arr)
        {
            float min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
            }
            return min;
        }

        static bool TrySumIfOdd(int a, int b, out int sum)
        {
            sum = a + b;
            if (sum % 2 == 0) return false;
            return true;
        }

        static void Repeat(string str, int n)
        {
            Console.Write(str);

            if (n > 1) Repeat(str, n - 1);
            else Console.Write('\n');
        }

        static void Fibonacci_Loop(int n)
        {
            int a = 1, b = 1;
            Console.Write("1 1 ");    
            for (int i = 2; i < n; i++)
            {
                b = a + b;
                a = b - a;
                Console.Write($"{b} ");
            }
            Console.WriteLine();
        }

        static void Fibonacci_rec(int n)
        {
            int a = 1, b = 1;
            Console.Write("1 1 ");
            Fibonacci_rec(a, b, n - 2);
        }

        static void Fibonacci_rec(int a, int b, int n)
        {
            b = a + b;
            a = b - a;
            Console.Write($"{b} ");

            if (n > 1) Fibonacci_rec(a, b, n - 1);
            else Console.WriteLine();
        }

        static void OutSqare(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((j == 0 || j == n - 1) || (i == 0 || i == n - 1))
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
        }

        static void OutCross(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == j) || (j == n - 1 - i))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void OutCircle(int r)
        {
            
            for (int i = 0; i <= r * 2; i++)
            {
                for (int j = 0; j <= r * 2; j++)
                {
                    if (r == Math.Round(Math.Sqrt(Math.Pow(r - i, 2) + Math.Pow(r - j, 2))))
                    {
                        Console.Write("██");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
	}
}