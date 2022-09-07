namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            string msg = "tayp{0,8}| \t.NET {1,8} |\tSize| = {2} (bayt) \t| Min ={3,30}\t| Max = {4}";
            Console.WriteLine("\n\t\t\t\t\t Цілочислові\n");
            Console.WriteLine(string.Format(msg, "byte", typeof(byte).Name, sizeof(byte), byte.MinValue, byte.MaxValue));
            Console.WriteLine(string.Format(msg, "sbyte", typeof(sbyte).Name, sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue));
            Console.WriteLine(string.Format(msg, "short", typeof(short).Name, sizeof(short), short.MinValue, short.MaxValue));
            Console.WriteLine(string.Format(msg, "ushort", typeof(ushort).Name, sizeof(ushort), ushort.MinValue, ushort.MaxValue));
            Console.WriteLine(string.Format(msg, "int", typeof(int).Name, sizeof(int), int.MinValue, int.MaxValue));
            Console.WriteLine(string.Format(msg, "uint", typeof(uint).Name, sizeof(uint), uint.MinValue, uint.MaxValue));
            Console.WriteLine(string.Format(msg, "long", typeof(long).Name, sizeof(long), long.MinValue, long.MaxValue));
            Console.WriteLine(string.Format(msg, "ulong", typeof(ulong).Name, sizeof(ulong), ulong.MinValue, ulong.MaxValue));
            Console.WriteLine("\n\t\t\t\t\t Числові з плаваючою крапкою!\n");
            Console.WriteLine(string.Format(msg, "float", typeof(float).Name, sizeof(float), float.MinValue, float.MaxValue));
            Console.WriteLine(string.Format(msg, "double", typeof(double).Name, sizeof(double), double.MinValue, double.MaxValue));
            Console.WriteLine(string.Format(msg, "decimal", typeof(decimal).Name, sizeof(decimal), decimal.MinValue, decimal.MaxValue));
            Console.WriteLine("\n\t\t\t\t\t Символні типи\n");
            Console.WriteLine(string.Format(msg, "char", typeof(char).Name, sizeof(char), char.MinValue, char.MaxValue));
            Console.WriteLine(string.Format(msg, "string", typeof(string).Name, "N/A", "N/A", "N/A"));
            Console.WriteLine("\n\t\t\t\t\t Логічний типи\n");
            Console.WriteLine(string.Format(msg, "bool", typeof(bool).Name, sizeof(bool), "N/A", "N/A"));
            Console.WriteLine("\n\t\t\t\t\t Особливий\n");
            Console.WriteLine(string.Format(msg, "object", typeof(object).Name, "N/A", "N/A", "N/A"));
            Console.WriteLine(string.Format(msg, "dynamic", "N/A", "N/A", "N/A", "N/A"));

            //
            // Part 1
            //

            Console.WriteLine("-------------HOMEWORK-------------\n\n**********Part1**********");

            byte firstValue = 23;
            short secondValue = 45;
            int thirdValue = 256;
            long fourthValue = -34843;
            bool fifthValue = true;
            char sixthsixthValue = '!';
            float seventhValue = 34;
            double eighthValue = 123.45;
            decimal ninthValue = 3232;
            string tenthValue = "Hello World";

            Console.WriteLine($"{firstValue}+{secondValue}={firstValue + secondValue}\n{thirdValue}-{fourthValue}={thirdValue - fourthValue}" +
                $"\n{seventhValue}/{eighthValue}={seventhValue / eighthValue}\n{tenthValue + sixthsixthValue}\n");

            //
            // Part2
            //

            Console.WriteLine("**********Part2**********\n");

            double x = 6;

            double result_1 = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
            double result_2 = Math.Abs(x) * Math.Sin(x);
            double result_3 = 2 * Math.PI * x;
            double result_4 = Math.Max(x, result_1);

            Console.WriteLine($"example 1 = {result_1}\nexample 2 = {result_2}\nexample 3 = {result_3}\nexample 4 = {result_4}\n");

            //
            // Part 3
            //

            Console.WriteLine("**********Part3**********\n");

            Console.WriteLine($"{365 - DateTime.Now.DayOfYear} days left to New Year\n{DateTime.Now.DayOfYear} days passed from New Year");
            Console.ReadLine();
        }
	}
}