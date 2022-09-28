namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int firstValue = 0;
            int secondValue = 0;
            int sum = 0;
            string str = "str ";

            Console.WriteLine("-------------HOME WORK------------");
                while (true)
                {
                    Console.Write("Enter first naumber\t");
                    if (int.TryParse(Console.ReadLine(), out firstValue))
                        break;
                    else
                        Console.WriteLine("incorectly naumber, try agein\t");
                }
                while (true)
                {
                    Console.Write("Enter second naumber\t");
                    if (int.TryParse(Console.ReadLine(), out secondValue))
                        break;
                    else
                        Console.WriteLine("incorectly naumber, try agein\t");
                }

            Console.WriteLine($"Your nauber:\nx = {firstValue}\ny = {secondValue}\n" +
                $"Max value = {MaxValue(firstValue, secondValue)}\nMin Value = {MinValue(firstValue,secondValue)}");
            Console.WriteLine($"sum is Odd - {TrySumIfOdd(firstValue,secondValue,out sum)}\t sum = {sum}");


            // extra
            Console.WriteLine("-------------Extra------------");
            RepeatSentence(str, firstValue);

            Console.WriteLine("\n--------------- HOMEWORK SUPER EXTRA 1 -------------");
            FibonachiFor(firstValue);
            Console.WriteLine();
            FibonachiRecurs(0,1,1,firstValue);

            Console.WriteLine("\n --------------- HOMEWORK SUPER EXTRA 2 ------------");
            DrowSquare(firstValue);
            DrowСross(firstValue);
            Console.ReadLine();
        }


        /*
         Define and call with different parameters next methods:

         Method that will return max value among all the parameters
         … min value …
         Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd,
         otherwise false, sum return as out parameter
         Overload first two methods with 3 and 4 parameters

         */

        static bool TrySumIfOdd(int firstValue, int secondValue, out int sum)
        {
            sum = firstValue + secondValue;
            return (sum) % 2 == 0;

        }
        static int MaxValue(int x, int y) => Math.Max(x, y);
        static int MaxValue(int x, int y, int z, int v) => Math.Max(x, Math.Max(y, Math.Max(z, v)));

        static int MinValue(int x, int y) => Math.Min(x, y);
        static int MinValue(int x, int y, int z) => Math.Min(x, Math.Min(y, z));

        /*
            second
            Extra:

            Define and call with different parameters next methods:

            Method Repeat that will accept string X and number N and return X repeated N times (e.g. Repeat(‘str’, 3)
            returns ‘strstrstr’ = ‘str’ three times)

        */

        static void RepeatSentence(string str, int count)
        {
            for (int i = 0; i <= count; i++)
                Console.Write(str);
        }

        /*
            HOMEWORK SUPER EXTRA 1

            Write methods (one using loops, another using recursion)
            that write to console n numbers of the Fibonacci sequence.

            For instance:

            n = 6

            OutPut: 1 1 2 3 5 8
            What is the Fibonacci sequence
        */

        static void FibonachiFor(int n)
        {
            int caunt = 0;
            int j = 1;
            Console.Write("1\t");
            for (int i = 0;;)
            {
                if (caunt == n) 
                    return;
                i += j;
                caunt++;
                Console.Write($"{i}\t");
                if (caunt == n)
                    return;
                j += i;
                Console.Write($"{j}\t");
                caunt++;

            }
        }

        static void FibonachiRecurs(int firstPsition, int secondPsition, int counter,int namber)
        {
            Console.Write($"{firstPsition}\t");
            if (counter<=namber)
            {
               FibonachiRecurs(secondPsition, firstPsition + secondPsition, counter + 1, namber);
            }

        }
             /*
                HOMEWORK SUPER EXTRA 2

                Write a method that prints a square figure. It accepts int n, where n is side length.

                Example

                n = 10;
            */
        static void DrowSquare(int naumber)
        {
            for (int i = 0; i <= naumber; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= naumber; j++)
                {
                    if (j == 0 || j == naumber||i==0||i== naumber)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
            }
        }
        static void DrowСross(int naumber)
        {
            int x = naumber;
            for (int i = 0; i <= naumber; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= naumber; j++)
                {
                    if (j == i)
                        Console.Write("*");
                    else if(j == x) 
                    { 
                        Console.Write("*");
                        x--;
                    }
                    else
                        Console.Write(" ");
                }
            }
        }
	}
}