namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.WriteLine("Enter x and y: ");
            string preinput = Console.ReadLine() ?? "0 0";
            string[] input = preinput.Split(' ');

            while (!(int.TryParse(input[0], out x) && int.TryParse(input[1], out y)))
            {
                Console.WriteLine("Invalid input. Try again");
                preinput = Console.ReadLine() ?? "0 0";
                input = preinput.Split(' ');
            }

            Console.WriteLine("--- Looppies ---");
            int sum = 0;
            float sum_f = 0;
            if (x == y) sum = x;
            else
            {
                if (x > y)
                {
                    Console.WriteLine("--- Super Extra 1 Swap ---");
                    x = x ^ y; // 1001 ^ 1000 -> 0001
                    y = x ^ y; // 0001 ^ 1000 -> 1001
                    x = y ^ x; // 1001 ^ 0001 -> 1000;		   

                    Console.WriteLine($"After swap: x: {x}, y: {y}");
                }
                for (int i = x; i <= y; i++)
                    sum += i;
                sum_f = (float)(x + y) / 2 * (y - x + 1); // only if d = 1
            }
            Console.WriteLine($"Sum with loop: {sum}\nSum with formula: {sum_f}");
            Console.WriteLine("\n--- Super Extra 2 Prime Numbers ---");
            Console.WriteLine($"Prime numbers in [{x}, {y}]");
            Console.WriteLine("- Something -");
            for (int i = x; i <= y; i++)
            {
                if (i == 1) continue;
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) Console.Write($"{i} ");
            }
            Console.WriteLine("\n- Sieve of Eratosthenes -");
            int n = y + 1;
            bool[] sieve = new bool[n];
            Array.Fill(sieve, true);
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (sieve[i] == true)
                {
                    int j = (int)Math.Pow(i, 2);
                    while (j < n)
                    {
                        sieve[j] = false;
                        j += i;
                    }
                }
            }
            for (int i = x; i < sieve.Length; i++)
            {
                if (sieve[i] == true) Console.Write(i + " ");
            }

        }
    }
}