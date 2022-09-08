namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte c = 13;
            int x = 10;
            int y = 20;
            long q = 0;
            double d = 2.2;
            decimal h = 0.0m;
            long f = 22l;
            char c2 = 's';
            string s = "Home Work";

            Console.WriteLine($"________________{s}_________________\n");
            Console.WriteLine(-6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15);
            Console.WriteLine();
            Console.WriteLine($"MAX  {Math.Max(x, y)}\n");
            Console.WriteLine($"abs X * Sin X {Math.Abs(x) * Math.Sin(x)}\n");
            Console.WriteLine($"2 * PI * 2 {2 * Math.PI * x}");


            Console.ReadLine();
        }
    }
}