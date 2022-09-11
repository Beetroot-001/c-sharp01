namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input first number:");
            var inputA = Console.ReadLine();
            int convertedAValue;
            bool isInt1 = Int32.TryParse(inputA, out convertedAValue);
            if (!isInt1)
            {
                Console.WriteLine("Invalid input");
                Environment.Exit(-1);
            }

            Console.WriteLine("Input second number:");
            var inputB = Console.ReadLine();
            int convertedBValue;
            bool isInt2 = Int32.TryParse(inputB, out convertedBValue);
            if (!isInt2)
            {
                Console.WriteLine("Invalid input");
                Environment.Exit(-1);
            }

            var minValue = Math.Min(convertedAValue, convertedBValue);
            var maxValue= Math.Max(convertedAValue, convertedBValue);

            List<int> list = new List<int>();


                for (int s = minValue; s <= maxValue; s++)
                {
                    list.Add(s);
                }
            Console.WriteLine("List of values:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine("---------------");

            if (minValue != maxValue)
            {
                Console.WriteLine("sum of all values: " + list.Sum());
            }
            else if (maxValue == minValue)
            {
                Console.WriteLine("sum of all values: " + minValue);
            }
        }
    }
}