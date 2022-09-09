namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int number2;
            bool num = true;
            bool num2 = true;


            do
            {
                try
                {
                    Console.WriteLine("Write the first number\n");
                    number = int.Parse(Console.ReadLine());
                    num = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception");
                    num = false;

                }

            } while (num == false);



            Console.WriteLine();
            do
            {
                try
                {
                    Console.WriteLine("Write a second number\n");
                    num2 = int.TryParse(Console.ReadLine(), out number2);

                }
                catch (Exception)
                {
                    Console.WriteLine("Exception");
                    Console.WriteLine("Write a second number\n");
                    num2 = int.TryParse(Console.ReadLine(), out number2);


                }

            } while (num2 == false);


            Console.WriteLine();
            int min = Math.Min(number2, number);
            int max = Math.Max(number2, number);
            int sum = min;

            if (min != max)
            {
                for (int i = min; i < max; i++)
                {
                    sum += i;
                }
            }
            else
            {
                Console.WriteLine($"The numbers are the same \n{number}\n");
            }
            Console.WriteLine($"The sum of all numbers between constants\n \n{min} and {max}\n");
            Console.WriteLine(sum);

            Console.ReadLine();
        }
    }
}