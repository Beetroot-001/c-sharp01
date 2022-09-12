namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===============Homework===============");

            SquarePrint(10);
            Console.WriteLine();
            CrossFigure(10);
            Console.WriteLine();
            WriteFibonacciSeqRecursion(6);
            Console.WriteLine();
            Console.WriteLine(Fibonacci(6));
            RepeatTask();
            Console.WriteLine();
            TrySumIfOddTask();
            Console.WriteLine();
            FindMixMaxTask();

            static void WriteFibonacciSeqRecursion(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(FibonacciRecursion(i) + " ");
                }
            }
            static void FindMixMaxTask(){
                int count = 2;
                int a = 0;
                int b = 0;
                int c = 0;
                int d = 0;
                string inputStr;
                Console.WriteLine();
                Console.WriteLine("Please enter 2 or 3 or 4 numbers to find max and min values.");

                bool check1 = true;
                bool check2 = true;
                bool check3 = true;
                bool check4 = true;

                do
                {
                    Console.Write("Enter your first number: ");
                    inputStr = Console.ReadLine();
                    check1 = int.TryParse(inputStr, out a);
                } while (!check1);


                do
                {
                    Console.Write("Enter your second number: ");
                    inputStr = Console.ReadLine();
                    check2 = int.TryParse(inputStr, out b);
                } while (!check2);


                do
                {
                    Console.Write("Enter your third number (OR 'Enter' key operate with only 2 numbers provided) : ");
                    inputStr = Console.ReadLine();
                    if (inputStr == "")
                    {
                        Console.WriteLine("Third number is cancelled!");
                        Console.WriteLine();
                        Console.WriteLine("HERE IS YOUR RESULTS OF 2 PROVIDED NUMBERS");
                        break;
                    }
                    else
                    {
                        check3 = int.TryParse(inputStr, out c);
                        if (check3)
                        {
                            count++;
                        }
                    }
                } while (!check3);


                if (count == 3)
                {
                    do
                    {
                        Console.Write("Enter your fourth number (OR 'Enter' key operate with only 3 numbers provided) : ");
                        inputStr = Console.ReadLine();
                        if (inputStr == "")
                        {
                            Console.WriteLine("Fourth number is cancelled!");
                            Console.WriteLine();
                            Console.WriteLine("HERE IS YOUR RESULTS OF 3 PROVIDED NUMBERS");
                            break;
                        }
                        else
                        {
                            check4 = int.TryParse(inputStr, out d);
                            if (check4)
                            {
                                count++;
                                Console.WriteLine();
                                Console.WriteLine("HERE IS YOUR RESULTS OF 4 PROVIDED NUMBERS");
                            }
                        }
                    } while (!check4);
                }


                if (count == 2)
                {
                    Console.WriteLine($"The max value between numbers {a}, {b} is {FindMax(a, b)}");
                    Console.WriteLine($"The min value between numbers {a}, {b} is {FindMin(a, b)}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"The max value between numbers {a}, {b}, {c} is {FindMax(a, b, c)}");
                    Console.WriteLine($"The min value between numbers {a}, {b}, {c} is {FindMin(a, b, c)}");
                }
                else
                {
                    Console.WriteLine($"The max value between numbers {a}, {b}, {c}, {d} is {FindMax(a, b, c, d)}");
                    Console.WriteLine($"The min value between numbers {a}, {b}, {c}, {d} is {FindMin(a, b, c, d)}");
                }
            }
            static void RepeatTask()
            {
                Console.WriteLine(Repeat("September. ", 3)); ;
            }
            static void TrySumIfOddTask()
            {
                Random random = new Random();

                int x = random.Next(100);
                int y = random.Next(100);
                int sum = 0;


                Console.WriteLine();
                Console.WriteLine("Using a Random number generator.");
                Console.WriteLine($"The 'TrySumIfOdd' method returns {TrySumIfOdd(x, y, out sum)} due to x = {x} and y = {y}");
            }
        }

        //FindMax 2
        static int FindMax(double a, double b)
        {
            return (int)(a > b ? a : b);

        }
        static int FindMax(int a, int b)
        {
            return a > b ? a : b;

        }
        static int FindMax(long a, long b)
        {
            return (int)(a > b ? a : b);

        }
        //FindMax 3
        static int FindMax(double a, double b, double c)
        {
            return (int)((a > b) ? (a > c ? a : c) : (b > c ? b : c));

        }
        static int FindMax(int a, int b, int c)
        {
            return (a > b) ? (a > c ? a : c) : (b > c ? b : c);

        }
        static int FindMax(long a, long b, long c)
        {
            return (int)((a > b) ? (a > c ? a : c) : (b > c ? b : c));

        }
        //FindMax 4
        static int FindMax(double a, double b, double c, double d)
        {
            return (int)((a > b) ? (a > c ? (a > d ? a : d) : (c > d ? c : d)) : (b > c ? (b > d ? b : d) : (c > d ? c : d)));
        }
        static int FindMax(int a, int b, int c, int d)
        {
            return (a > b) ? (a > c ? (a > d ? a : d) : (c > d ? c : d)) : (b > c ? (b > d ? b : d) : (c > d ? c : d));
        }
        static int FindMax(long a, long b, long c, long d)
        {
            return (int)((a > b) ? (a > c ? (a > d ? a : d) : (c > d ? c : d)) : (b > c ? (b > d ? b : d) : (c > d ? c : d)));
        }
        //FindMin 2
        static int FindMin(double a, double b)
        {
            return (int)(a < b ? a : b);

        }
        static int FindMin(int a, int b)
        {
            return a < b ? a : b;

        }
        static int FindMin(long a, long b)
        {
            return (int)(a < b ? a : b);

        }
        //FindMin 3
        static int FindMin(double a, double b, double c)
        {
            return (int)((a < b) ? (a < c ? a : c) : (b < c ? b : c));
        }
        static int FindMin(int a, int b, int c)
        {
            return (a < b) ? (a < c ? a : c) : (b < c ? b : c);
        }
        static int FindMin(long a, long b, long c)
        {
            return (int)((a < b) ? (a < c ? a : c) : (b < c ? b : c));
        }
        //FindMin 4
        static int FindMin(double a, double b, double c, double d)
        {
            return (int)((a < b) ? (a < c ? (a < d ? a : d) : (c < d ? c : d)) : (b < c ? (b < d? b : d) : (c < d? c : d)));
        }
        static int FindMin(int a, int b, int c, int d)
        {
            return (a < b) ? (a < c ? (a < d ? a : d) : (c < d ? c : d)) : (b < c ? (b < d ? b : d) : (c < d ? c : d));
        }
        static int FindMin(long a, long b, long c, long d)
        {
            return (int)((a < b) ? (a < c ? (a < d ? a : d) : (c < d ? c : d)) : (b < c ? (b < d ? b : d) : (c < d ? c : d)));
        }

        static int TrySumIfOdd(int x, int y, out int sum)
        {
            if (x % 2 != 0 && y % 2 != 0)
            {
                sum = x + y;
                return sum;
            }
            else
            {
                sum = -1;
                return sum;
            }

        }

        static string Repeat(string X, int n)
        {
            if (n <= 0 || n==1)
            {
                return X;
            }

            return X + Repeat(X, n-1);
        }

        static string Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            string result = null;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;

                result += a.ToString() + " ";
            }
            return result;
        }

        static int FibonacciRecursion(int n)
        {

            if (n == 0)
            {
                return 0;
            }  
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return FibonacciRecursion(n - 2) + FibonacciRecursion(n - 1);
            }

        }

        static void SquarePrint(int n)
        {

            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 || i == 9)
                    {
                        Console.Write("*");
                    }
                    else if (j == 0 || j == 9)
                    {
                        Console.Write("2");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        static void CrossFigure(int n)
        {
            int i, j;
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    if (i == j || j == (n - i + 1))
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