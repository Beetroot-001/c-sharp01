using System;
using System.Diagnostics.Metrics;

namespace ConsoleApp1
{
	internal class Program
	{
        public static int MaxValue(int a, int b)
        {
            int result = a > b ? a : b;

            return result; 
        }

     
        public static int MaxValue(int a, int b, int c)
		{
            int maxResult = MaxValue(a, b);

            return MaxValue(maxResult, c);         
        }

        public static int MaxValue(int a, int b, int c, int d)
        {
            int maxResult = MaxValue(a, b,c);

            return MaxValue(maxResult, d);
        }


        public static int MinValue(int a, int b)
        {
            int result = a < b ? a : b;

            return result;
        }


        public static int MinValue(int a, int b, int c)
        {
            int minResult = MaxValue(a, b);

            return MaxValue(minResult, c);
        }

        public static int MinValue(int a, int b, int c, int d)
        {
            int minResult = MaxValue(a, b,c);

            return MaxValue(minResult, d);
        }

        public static bool TrySumIfOdd(int a, int b, out int sum)
        {
            sum = 0;

            for (int i = a; i < b; i++)
            {
                sum += i;
            }

           bool result = sum % 2 != 0 ? true : false;

           return result;
        }


        public static void Repeat(string s, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(s);
            }
        }

        public static void Repeat2(string s, int n)
        {
            if (n>0)
            {
                Console.Write(s);
                Repeat2(s, --n);
            }
            else
            {
                return;
            }
        }

        static void Main(string[] args)
		{

            Console.WriteLine("/////////////Homework 1.1.Max Value Method//////////////");

            int resultMaxValue = MaxValue(91, 118,6,12);
            Console.WriteLine(resultMaxValue);

            Console.WriteLine("/////////////Homework 1.2. Min Value Method//////////////");

            int resultMinValue = MinValue(2, 8, 1);
            Console.WriteLine(resultMinValue);

            Console.WriteLine("/////////////Homework 1.3. TrySumIfOdd Method//////////////");

            int sum;
            Console.WriteLine(TrySumIfOdd(3, 6, out sum));
            
            Console.WriteLine(sum);

            Console.WriteLine("/////////////Homework Extra. Repeat Method//////////////");

            Repeat("vasia", 3);  ///Loop method
            Console.WriteLine();
           
            Repeat2("123", 3); ///recursion method 
            Console.WriteLine();

            Console.WriteLine("/////////////Homework Super Extra 1. Fibonacci Method//////////////");

            static void Fibonacci(int counter)
            {
                int num1 = 0;
                int num2 = 1;

                for (int i = 0; i < counter; i++)
                {
                    Console.Write($"{num2} ");
                    num2 += num1;
                    num1 = num2 - num1;
                }
            }

            Fibonacci(12);

            Console.WriteLine();

            static void Fibonacci2(int counter, int num1 = 0, int num2 = 1)
            {
                if (counter == 0)
                {
                    return;
                }
                else
                {
                    Console.Write($"{num2} ");
                    num2 += num1;
                    num1 = num2 - num1;                  
                    counter--;
                    Fibonacci2(counter, num1, num2);
                }
            }

            Fibonacci2(12);
            Console.WriteLine();

            Console.WriteLine("/////////////Homework Super Extra 2. Print Figures//////////////");

            int counter = 10;

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    if (i > 0 && i < counter - 1 && j > 0 && j < counter - 1)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();          
            
            int counter2 = 10;          

            for (int i = 0; i < counter2; i++)
            {
                for (int k = 0; k <= counter2; k++)
                {
                    if (k == i || k == counter2 - i-1)
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
	}
}