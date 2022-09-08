namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task #1
            Console.WriteLine("===========HOMEWORK===========");
            int x = 1;
            int y = -6;
            int sum = 0;

            if (x == y)
            {
                sum = x;
            }
            else
            {
                for (int i = Math.Min(x, y); i <= Math.Max(x, y); i++)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);


            //Task #2 
            Console.WriteLine("===========HOMEWORK2===========");

            bool intChecker, intChecker2;
            sum = 0;
            x = 0;
            y = 0;

            do
            {
                Console.Write("Enter the first number: ");
                string input1 = Console.ReadLine();
                intChecker = int.TryParse(input1, out x);
                Console.Write("Enter the second number: ");
                string input2 = Console.ReadLine();
                intChecker2 = int.TryParse(input2, out y);

                if (!intChecker || !intChecker2)
                {
                    Console.WriteLine("WRONG INPUT");
                    Console.WriteLine("Please, enter a valid integer values!");
                    Console.WriteLine();
                }
            } while (!intChecker || !intChecker2);

            if (x == y)
            {
                sum = x;
            }
            else
            {
                for (int i = Math.Min(x, y); i <= Math.Max(x, y); i++)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);

            //Task #3
            Console.WriteLine("===========SUPER EXTRA 1==========");
            int a = 7;
            int b = 5;
            Console.WriteLine($"Before: a = {a}, and b = {b}");

            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"After: a = {a}, and b = {b}");


            //Task #4
            Console.WriteLine("===========SUPER EXTRA 2==========");
            x = 0;
            y = 0;
            int count = 0;

            do
            {
                Console.Write("Enter the first number: ");
                string input1 = Console.ReadLine();
                intChecker = int.TryParse(input1, out x);
                Console.Write("Enter the second number: ");
                string input2 = Console.ReadLine();
                intChecker2 = int.TryParse(input2, out y);

                if (!intChecker || !intChecker2)
                {
                    Console.WriteLine("WRONG INPUT");
                    Console.WriteLine("Please, enter a valid integer values!");
                    Console.WriteLine();
                }
            } while (!intChecker || !intChecker2);

            for (int i = Math.Min(x, y); i < Math.Max(x, y); i++)
            {
                for (int j = Math.Min(x, y); j < Math.Max(x, y); j++)

                {
                    if (i % j == 0)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    Console.Write(i + " ");
                }
                count = 0;
            }
        }
    }
}