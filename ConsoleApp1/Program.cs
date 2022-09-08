namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int res_cycle = 0;
            int res_formula = 0;

            //input numbers(extra 0)
            Program.input(out a, out b);

            Console.WriteLine("your input: a - " + a + " b - " + b);

            //extra 1
            if (a > b)
            {
                // example
                // a = 8, b = 3
                a = a + b; // a = 11 = 8 + 3
                b = a - b; // b = 8 = 11 - 3
                a = a - b; // a = 3 = 11 - 8
                Console.WriteLine("change numbers: a - " + a + " b - " + b);
            }

            //main homework 

            //using formula
            res_formula = (a + b) * (Math.Abs(a - b) + 1) / 2;

            //using cycle
            //var a will be needed later, create i
            for (int i = a; i <= b; res_cycle += i, i++) { }

            Console.WriteLine("\n--==sum of all numbers==--");

            //compare and out results
            if (res_cycle != res_formula)
            {
                Console.WriteLine("result using formula: " + res_formula);
                Console.WriteLine("result using cycle: " + res_cycle);
            }
            else
                Console.WriteLine("results is equal: " + res_cycle);

            //extra 2
            Console.WriteLine("\n--==prime numbers==--");
            bool exist = false; // flag to check existence of prime numbers
            //if a = 1, then start with 2, because 1 isn`t prime
            //if a > 2 and evenm, then start with next odd
            for (a = a <= 2 ? 2 : a + (a % 2 == 0 ? 1 : 0);
                a <= b;
                a += a != 2 ? 2 : 1) //skip all even nums exept 2
            {
                if (is_prime(a))
                {
                    Console.Write(a + " ");
                    exist = true;
                }
            }
            if (!exist)
            {
                Console.WriteLine("there is no prime numbers");
            }
        }

        //input method
        static void input(out int a, out int b)
        {
            string? input_str = null;
            Console.WriteLine("input two numbers");
            Console.WriteLine("input first number:");

            do
            {
                input_str = Console.ReadLine();
                if (!int.TryParse(input_str, out a))
                {
                    Console.WriteLine("incorrect input");
                }
                else
                    break;

            } while (true);

            Console.WriteLine("input second number:");

            do
            {
                input_str = Console.ReadLine();
                if (!int.TryParse(input_str, out b))
                {
                    Console.WriteLine("incorrect input");
                }
                else
                    break;
            } while (true);

        }

        //prime number check
        static bool is_prime(int a)
        {
            for (int i = 2; i <= Math.Sqrt(a); i++)
                if (a % i == 0)
                    return false;
            return true;
        }
    }
}