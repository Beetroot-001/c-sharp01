
namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            byte b1 = 0;
            short s1 = 0;
            int i1 = 0;
            long l1 = 0;
            bool b2 = false;
            char c1 = 'a';
            float f1 = 0.0f;
            decimal d1 = 0.0m;
            string s2 = String.Empty;

            double x = 15;
            double y = 6;

            Console.WriteLine(calc1(x));
            Console.WriteLine("/////*** 1/////");
            Console.WriteLine(calc2(x));
            Console.WriteLine("/////*** 2/////");
            Console.WriteLine(calc3(x));
            Console.WriteLine("/////*** 3/////");
            Console.WriteLine(calc4(x,y));
            Console.WriteLine("/////*** 4/////");
            Console.WriteLine(leftToNY());
            Console.WriteLine("/////*** 5/////");
            Console.WriteLine(leftFromNY());            
            Console.WriteLine("/////Extra/////");
            Console.WriteLine(leftToNY2("01.01.2022", "12.05.2022"));
		}

        static double calc1(double x) => -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
        static double calc2(double x) => Math.Abs(x) * Math.Abs(x);
        static double calc3(double x) => 2 * Math.PI * x;
        static double calc4(double x, double y) => Math.Max(x,y);
        static int leftToNY() => DateTime.Now.DayOfYear;
        static int leftFromNY() => DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365 - leftToNY();
        static int leftToNY2(string startDate, string endDate)
        {
            var sDate = DateTime.Parse(startDate);
            var eDate = DateTime.Parse(endDate);
            var mondaysCount = 0;
            while(sDate <= eDate)
            {
                if((int)sDate.DayOfWeek == 1)
                {
                    mondaysCount++;
                }
                sDate = sDate.AddDays(1);
            }

            return mondaysCount;
        }

    }
}