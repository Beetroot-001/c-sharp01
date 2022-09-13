using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float x_f = 2.3f, y_f = 4.5f;
            double x_d = 4.5, y_d = 10.0;
            int x_i = 3, y_i = 5;

            Console.WriteLine($"Min of {x_f} and {y_f} is: {Min(x_f, y_f)}");
            Console.WriteLine($"Min of {x_d} and {y_d} is: {Min(x_d, y_d)}");
            Console.WriteLine($"Min of {x_i} and {y_i} is: {Min(x_i, y_i)}");
            Console.WriteLine($"Max of {x_f} and {y_f} is: {Max(x_f, y_f)}");
            Console.WriteLine($"Max of {x_d} and {y_d} is: {Max(x_d, y_d)}");

            Console.WriteLine("Enter size for square: ");
            int size = Input();
            DrawSquare(size);
            Console.WriteLine("Enter size for X: ");
            int size_x = Input();
            DrawX(size_x);
            Console.WriteLine("Enter limit number for Fibonacci: ");
            int result = Input();
            Fibonacchi(0, 1, result);
            Console.WriteLine("Enter string to repeat: ");
            string? line = Console.ReadLine();
            Console.WriteLine("Enter count to repeat: ");
            int count = Input();
            Console.WriteLine(Repeat(line, count));

            Console.WriteLine("Try sum if odd\nEnter x:");
            int x = Input();
            Console.WriteLine("Enter y:");
            int y = Input();
            int z;
            bool success = TrySumIfOdd(x, y, out z);

            if (success) Console.WriteLine("Sum is odd: " + z);
            else Console.WriteLine("Sum is even");
        }

        static string Repeat(string x, int number)
        {   
            x = x ?? String.Empty;
            if (number == 0) return String.Empty;
            else return x + Repeat(x, --number);

            Console.WriteLine($"{x}");
        }
        static int Max(params int[] values)
        {
            int max = values[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (max < values[i])
                    max = values[i];
            }
            return max;
        }
        static int Min(params int[] values)
        {
            int min = values[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (min > values[i])
                    min = values[i];
            }
            return min;
        }

        static int Max(int x, int y)
        {
            return x < y ? y : x;
        }

        static float Max(float x, float y)
        {
            return x < y ? y : x;
        }
        static double Max(double x, double y)
        {
            return x < y ? y : x;
        }
        static int Min(int x, int y)
        {
            return x > y ? y : x;
        }
        static float Min(float x, float y)
        {
            return x > y ? y : x;
        }
        static double Min(double x, double y)
        {
            return x > y ? y : x;
        }

        static bool TrySumIfOdd(int x, int y, out int z)
        {
            z = (x + y) % 2 == 0 ? -1 : x + y;
            return (x + y) % 2 == 0;
        }

        static void Fibonacchi(int first, int second, int final)
        {
            if (final <= second)
            {
                Console.WriteLine($"{first} {second}");
                return;
            }
            else
            {
                int sum = first + second;
                Console.Write($"{first} ");
                Fibonacchi(second, sum, final);
            }
        }

        static int Input()
        {
            string? input = Console.ReadLine();
            int result;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Invalid input. Try again...");
                input = Console.ReadLine();
            }
            return result;
        }

        static void DrawSquare(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0 || i == n-1 || j == n-1)
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
        static void DrawX(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == j || n-1-i == j)
                        Console.Write('*');
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
            
        }
    }
}