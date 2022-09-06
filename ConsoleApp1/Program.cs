namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte b1 = 3;
			byte b2 = 4;

			short s1 = 5;
			short s2 = 6;

			int in1 = 7;
			int in2 = 8;

			long l1 = 25250150001;
			long l2 = 25250150002;

			bool isDynamic = true;
			bool isStatic = false;

			char c1 = 'a';
			char c2 = '\u0056';
			char c3 = '\x001A';
			char c4 = (char)1111;

			Console.WriteLine($"{c1}, {c2}, {c3}, {c4}");

			float f1 = 0.03f;
			float f2 = 0.0000015f;

			double d1 = 0.06;
			double d2 = 0.001;

			decimal price1 = 1.5666m;
			decimal price2 = 4.000000000000000000000002m;

			string firstName = "Andrii";
			string lastName = "Kovalenko";
			string stringDivider = new string('=', 40);

			string operation = "Addition";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			Console.WriteLine($"The sum of {b1} + {b2} = {b1 + b2}");
			Console.WriteLine($"The sum of {s1} + {s2} = {s1 + s2}");
			Console.WriteLine($"The sum of {in1} + {in2} = {in1 + in2}");
			Console.WriteLine($"The sum of {l1} + {l2} = {l1 + l2}");
			Console.WriteLine($"The result of addition 2 chars '{c1}' and '{c4}': {c1 + c4}");
			Console.WriteLine($"The result of addition of 2 floats {f1} + {f2} = {f1 + f2}");
			Console.WriteLine($"The sum of {d1} + {d2} = {d1 + d2}");
            Console.WriteLine($"The sum of {price1} + {price2} = {price1 + price2}" );
            Console.WriteLine($"The sum of different type values casted to DOUBLE is {b1} + {s2} + {in1} + {l2} + {f1} + {d2} +" +
				$"{c4} = {(double)b1 + (double)s2 + (double)in1 + (double)l2 + (double)f1 + (double)d2 + (double)c4}");

            Console.WriteLine(firstName + " " + lastName);

            Console.WriteLine();
			operation = "Substraction";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			Console.WriteLine($"The difference of {b1} - {b2} = {b1 - b2}");
			Console.WriteLine($"The difference of {s1} - {s2} = {s1 - s2}");
			Console.WriteLine($"The difference of {in1} - {in2} = {in1 - in2}");
			Console.WriteLine($"The difference of {l1} - {l2} = {l1 - l2}");
			Console.WriteLine($"The result of difference 2 chars '{c4}' and '{c1}': {c4 - c1}");
			Console.WriteLine($"The result of difference 2 floats {f1} - {f2} = {f1 + f2}");
			Console.WriteLine($"The difference of {d1} - {d2} = {d1 - d2}");
			Console.WriteLine($"The difference of {price1} - {price2} = {price1 - price2}");
			Console.WriteLine($"The difference of different type values casted to DOUBLE is {l2} - {s2} - {in1} - {b2} - {f1} - {d2} -" +
				$"{c4} = {(double)l2 - (double)s2 - (double)in1 - (double)b2 - (double)f1 - (double)d2 - (double)c4}");

			operation = "Multiplication";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			Console.WriteLine($"The product of {b1} * {b2} = {b1 * b2}");
			Console.WriteLine($"The product of {s1} * {s2} = {s1 * s2}");
			Console.WriteLine($"The product of {in1} * {in2} = {in1 * in2}");
			Console.WriteLine($"The product of {l1} * {l2} = {l1 * l2}");
			Console.WriteLine($"The result of product 2 chars '{c4}' and '{c1}': {c4 * c1}");
			Console.WriteLine($"The result of product 2 floats {f1} * {f2} = {f1 * f2}");
			Console.WriteLine($"The product of {d1} * {d2} = {d1 * d2}");
			Console.WriteLine($"The product of {price1} * {price2} = {price1 * price2}");
			Console.WriteLine($"The product of different type values casted to DOUBLE is {l2} * {s2} * {in1} * {b2} * {f1} * {d2} * " +
				$"{c4} = {(double)l2 * (double)s2 * (double)in1 * (double)b2 * (double)f1 * (double)d2 * (double)c4}");

			operation = "Dividing";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			Console.WriteLine($"The quotient of {b2} / {b1} = {b2 / b1}");
			Console.WriteLine($"The quotient of {s1} / {s2} = {s1 / s2}");
			Console.WriteLine($"The quotient of {in2} / {in1} = {in2 / in1}");
			Console.WriteLine($"The quotient of {l2} / {l1} = {l2 / l1}");
			Console.WriteLine($"The result of quotient 2 chars '{c4}' and '{c1}': {c4 / c1}");
			Console.WriteLine($"The result of quotient 2 floats {f1} / {f2} = {f1 / f2}");
			Console.WriteLine($"The quotient of {d1} / {d2} = {d1 / d2}");
			Console.WriteLine($"The quotient of {price1} / {price2} = {price1 / price2}");
			Console.WriteLine($"The quotient of different type values casted to DOUBLE is {l2} / {s2} / {in1} / {b2} / {f1} / {d2} / " +
				$"{c4} = {(double)l2 / (double)s2 / (double)in1 / (double)b2 / (double)f1 / (double)d2 / (double)c4}");

			operation = "Remaining";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			Console.WriteLine($"The remainder of {b2} % {b1} = {b2 % b1}");
			Console.WriteLine($"The remainder of {s1} % {s2} = {s1 % s2}");
			Console.WriteLine($"The remainder of {in2} % {in1} = {in2 % in1}");
			Console.WriteLine($"The remainder of {l2} % {l1} = {l2 % l1}");
			Console.WriteLine($"The result of remainder 2 chars '{c4}' and '{c1}': {c4 % c1}");
			Console.WriteLine($"The result of remainder 2 floats {f1} % {f2} = {f1 % f2}");
			Console.WriteLine($"The remainder of {d1} % {d2} = {d1 % d2}");
			Console.WriteLine($"The remainder of {price1} % {price2} = {price1 % price2}");
			Console.WriteLine($"The remainder of different type values casted to DOUBLE is {l2} % {s2} % {in1} % {b2} % {f1} % {d2} % " +
				$"{c4} = {(double)l2 % (double)s2 % (double)in1 % (double)b2 % (double)f1 % (double)d2 % (double)c4}");

			operation = "Math Functions Result";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			var x = 2;
			var y = 1;
            Console.WriteLine(-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15); 
            Console.WriteLine($"{Math.Abs(x)} * {Math.Sin(x)} = {Math.Abs(x) * Math.Sin(x)}");
            Console.WriteLine($"2 * {Math.PI} * {x} = {2 * Math.PI * x}");
            Console.WriteLine(Math.Max(x, y));
            Console.WriteLine();

			operation = "EXTRA";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			DateTime dateTime = DateTime.Now;
			var daysPassed = DateTime.Now.DayOfYear;
            var daysRemain = DateTime.IsLeapYear(dateTime.Year) ? 366 - daysPassed : 365 - daysPassed;
            Console.WriteLine($"Current daytime is {dateTime}");
			Console.WriteLine($"Passed days of current year: {daysPassed}");
			Console.WriteLine($"Remaining days to next year: {daysRemain}");
            


			operation = "SUPER EXTRA";
			Console.WriteLine("\n" + stringDivider + " " + operation + " " + stringDivider);
			DateTime startDate = new DateTime(2022, 7, 30);
			DateTime endDate = new DateTime(2022, 9, 1);
            Console.WriteLine(startDate > endDate);
            if (startDate > endDate)
            {
				var temp = startDate;
				startDate = endDate;
				endDate = temp;
            }
			
            Console.WriteLine(CountDays(DayOfWeek.Monday, startDate, endDate));

			static int CountDays(DayOfWeek day, DateTime startDate, DateTime endDate)
			{
				TimeSpan ts = endDate - startDate;                       
				int count = (int)(ts.TotalDays / 7);   
				int remainder = (int)(ts.TotalDays % 7);         
				int sinceLastDay = (int)(endDate.DayOfWeek - day);
				if (sinceLastDay < 0)
                {
					sinceLastDay += 7;
				}      

				
				if (remainder >= sinceLastDay)
                {
					count++;
				}

				return count;
			}
		}
	}
}