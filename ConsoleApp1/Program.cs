namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte b = 255;
            short sh = 260;
            int i = 2000000;
            long l = 4;
            bool bl = true;
            float f = 3.2f;
            double d = 5.6;
            decimal m = 7.9m;
            string str = "Hello, World";
            char ch = '!';

            if (!!bl)
                Console.WriteLine("addition " +
                    (f + d));

            Console.WriteLine("substraction " +
                (sh - b));

            Console.WriteLine("multiplication " +
                (b * f));

            Console.WriteLine("addition(string) " +
                (str + ch));

            Console.WriteLine("division " +
                (i / l));


            Console.WriteLine("\n--==Math functions==--\n");

            int x = 5;

            Console.WriteLine("-6*x^3+5*x^2-10*x+15 : " +
                (-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) -
                10 * x + 15)
                /*(- 6 * Math.Pow(x, 3) + Math.Pow(5, x) - 
				Math.Pow(10, x) + 15)*/ +
                '\n');

            x = -1;
            Console.WriteLine("abs(x)*sin(x) : " +
                (Math.Abs(x) * Math.Sin(x)) +
                '\n');

            x = 2;
            Console.WriteLine("2 * pi * x : " +
                (2 * Math.PI * x) +
                '\n');

            int y = 300;
            Console.WriteLine("max(x, y) : " +
                (Math.Max(x, y)) +
                '\n');

            Console.WriteLine("--==Extra==--\n");

            Console.WriteLine("days left to New Year: " +
                (new DateTime(DateTime.Today.Year + 1, 1, 1, 12, 0, 0) -
                DateTime.Today).Days +
                '\n');

            Console.WriteLine("days passed from New Year: " +
                (DateTime.Today -
                new DateTime(DateTime.Today.Year, 1, 1, 12, 0, 0)).Days +
                '\n');
        }
    }
}