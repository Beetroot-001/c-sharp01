namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("---Varibles---\n");
			byte x = 5;
			int y = -2;
			short z = 10;

            sbyte _sbyte = 127;
            byte _byte = 255;
            short _short = 32767;
            long _long = 1000000;
            bool _bool = false;
            decimal _decimal = 8.00m;
            decimal _decimal2 = 9.00m;

            Console.WriteLine(_byte + _short); // all good
            Console.WriteLine(_bool && _bool); // cannot assign + to bool types (false && false -> false)
            Console.WriteLine(_decimal + _long); // all good
            Console.WriteLine(++_sbyte); // 127 -> -128
            Console.WriteLine(++_byte); // 255 -> 0

            Console.WriteLine(_decimal - _decimal2); // -1.00
            Console.WriteLine(--_byte / --_sbyte); // 2

            uint x1 = 0b_1000;
			Console.WriteLine(x1);
            Console.WriteLine("\n---Shift and binary numbers---\n");
			x1 = x1 >> 1;
            Console.WriteLine(x1); // 0100
            x1 <<= 1;
            Console.WriteLine(x1); // 1000
			x1 <<= 3;
			Console.WriteLine(x1); // 0100 0000
            Console.WriteLine("\n---Calculations---\n");
			int result = x++ + y - --z * y++;

			// 1. --z = 9
			// 2. z*y = -18
			// 3. x + y = 3
			// 4. 3 - -18 = 21 // result
			// 5. x++ = 6
			// 6. y++ = -1

			Console.WriteLine($"X: {x}, Y: {y}, Z: {z}, Total: {result}");

            double result1 = 0;
            x = 5;
            result1 = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
            // 1. Math.Pow(x,3) = 125
            // 2. Math.Pow(x,2) = 25
            // 3. -6 * 125 = -750
            // 4. 5 * 25 = 125
            // 5. 10 * x = 50
            // 6. -750 + 125 - 50 + 15 = -660
            Console.WriteLine("-6*x^3+5*x^2-10*x+15\n result: " + result1);
            
            result1 = Math.Abs(x) * Math.Sin(x);
            // 1. Math.Abs(x)
            // 2. Math.Sin(x)
            // 3. *
            Console.WriteLine("abs(x)*sin(x)\n result: " + result1);

            result1 = 2 * Math.PI * x;
            // 1. Math.Pi
            // 2. 2 * PI
            // 3. * x
            Console.WriteLine("2*pi*x\n result: " + result1);

            result1 = Math.Max(x, y); 
            // 1. Max result :)
            Console.WriteLine("max(x, y)\n result: " + result1);

            Console.WriteLine("\n---Boolean math---\n");

            bool b1 = true | true & false; // true
            bool b2 = (true | true) & false; // false
            bool b3 = !true && true | false; // false

            Console.WriteLine("First test: {0}\nSecond test: {1}\nThird test: {2}", b1, b2, b3);

            // Extra hw with datetime and timespan enums
            Console.WriteLine("\n---DateTime---\n");
            DateTime currentDate = DateTime.Today; 
            DateTime NewYear = new DateTime(2022, 1, 1); // the most optimal way?
            DateTime NextNewYear = new DateTime(2023, 1, 1);

            TimeSpan left = NextNewYear - currentDate;
            TimeSpan passed = currentDate - NewYear;
            Console.WriteLine("{0} days left to New Year\n{1} days passed from New Year", left.Days, passed.Days);

            Console.WriteLine("\n---Extra DateTime---\n");

            var startDate = DateTime.Now; 
            //startDate = startDate.AddDays(-1); //Test for monday on both edges (It is Tuesday now)
            var endDate = startDate.AddDays(200); // not static method, so needs a variable // 200 is ok, 202 is not :) // now it's all okay (hopefully)

            Console.WriteLine("Start day: " + startDate.DayOfYear + " " + "Start day name: "+ startDate.DayOfWeek);
            Console.WriteLine("End day: " + endDate.DayOfYear + " " + "End day name: " + endDate.DayOfWeek);

            TimeSpan time = endDate - startDate;
            int mondaysCount = time.Days / 7;
            bool mondayOnEdge = endDate.DayOfWeek == DayOfWeek.Monday || startDate.DayOfWeek == DayOfWeek.Monday;
            mondaysCount = (mondayOnEdge) ? ++mondaysCount : mondaysCount;
            
            // TEST
            int count = 0;
            while (startDate <= endDate)
            {
                if (startDate.DayOfWeek == DayOfWeek.Monday) count++;
                startDate = startDate.AddDays(1);
            }

            Console.WriteLine("Iterative: " + count);
            Console.WriteLine("My calulation: " + mondaysCount);

            string message = (count == mondaysCount) ? "Test passed :)" : "Test failed :(";
            Console.WriteLine(message);
        }
	}
}