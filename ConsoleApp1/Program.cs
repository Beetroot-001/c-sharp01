namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte b_num_from = 0;
			byte b_num_to = 255;

			short s_num_from = -32768;
			short s_num_to = 32767;

			int i_num_from = -2147483648;
			int i_num_to = 2147483647;

			long l_num_from = -9223372036854775808;
			long l_num_to = 9223372036854775807;

			//bool b_log_from = true;
			//bool b_log_to = false;

			//char c_variable = '\u006A';

			float f_num = 1.1234f;
			float fa_num = 0.0034f;

			double d_num = 1.1234d;
			double da_num = 0.0034d;

			decimal de_num = 1.1234m;
			decimal dea_num = 0.0034m;

			string str_variable = "test this";

            Console.WriteLine(b_num_from + b_num_to);
            Console.WriteLine(s_num_from + s_num_to);
            Console.WriteLine(i_num_from + i_num_to);
            Console.WriteLine(l_num_from + l_num_to);
            Console.WriteLine(f_num + fa_num);
            Console.WriteLine(d_num + da_num);
            Console.WriteLine(de_num + dea_num);
            Console.WriteLine(str_variable);

			Console.WriteLine(b_num_from / b_num_to);
			Console.WriteLine(s_num_from / s_num_to);
			Console.WriteLine(i_num_from / i_num_to);
			Console.WriteLine(l_num_from / l_num_to);
			Console.WriteLine(f_num / fa_num);
			Console.WriteLine(d_num / da_num);
			Console.WriteLine(de_num / dea_num);

			Console.WriteLine(b_num_from * b_num_to);
			Console.WriteLine(s_num_from * s_num_to);
			Console.WriteLine(i_num_from * i_num_to);
			Console.WriteLine(l_num_from * l_num_to);
			Console.WriteLine(f_num * fa_num);
			Console.WriteLine(d_num * da_num);
			Console.WriteLine(de_num * dea_num);

			int x = 5;
			int y = 3;
			Console.WriteLine("this is the result: " + (-6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15));
			Console.WriteLine("Abs: " + Math.Abs(x) * Math.Sin(x));
			Console.WriteLine("PI: " + 2 * Math.PI * x);
			Console.WriteLine("Max: " + Math.Max(x, y));

			Console.WriteLine("---DateTimePractice---");

			DateTime date = DateTime.Today;
			int dayOfTheYear = date.DayOfYear;
			int daysInYear = DateTime.IsLeapYear(date.Year) ? 366 : 365;

            Console.WriteLine(date);
            Console.WriteLine(dayOfTheYear);
            Console.WriteLine(daysInYear);
            Console.WriteLine((daysInYear - dayOfTheYear) + " days left to New Year");
            Console.WriteLine(dayOfTheYear + " days passed from New Year");

			var startDate = DateTime.Now;
			var endDate = startDate.AddDays(200);

			int mondayCount = 0;

            for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1.0))
            {
                if (dt.DayOfWeek == DayOfWeek.Monday)
                {
					mondayCount++;
				}
            }
            Console.WriteLine("mondayCount is " + mondayCount);

		}
	}
}