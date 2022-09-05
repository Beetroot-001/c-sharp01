using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte b1; // Min: 0: max 255
			sbyte b2; // -127..126
			short s1;
			long l1;
			ushort us2;
			ulong us3;
			uint us4;
			int b3;

			Console.WriteLine("---------------INTEGER-----------");
			// integer numbers 
			Console.WriteLine($"Max byte: {byte.MinValue} min: {byte.MaxValue}");
			Console.WriteLine($"Max sbyte: {sbyte.MinValue} min: {sbyte.MaxValue}");
			Console.WriteLine($"Max short: {short.MinValue} min: {short.MaxValue}");
			Console.WriteLine($"Max ushort: {ushort.MinValue} min: {ushort.MaxValue}");
			Console.WriteLine($"Max int: {int.MinValue} min: {int.MaxValue}");
			Console.WriteLine($"Max uint: {uint.MinValue} min: {uint.MaxValue}");
			Console.WriteLine($"Max long: {long.MinValue} min: {long.MaxValue}");
			Console.WriteLine($"Max ulong: {ulong.MinValue} min: {ulong.MaxValue}");


			Console.WriteLine("---------------FLOATING-----------");
			// floating numbers
			float f1;
			double d1;
			decimal m1;

			Console.WriteLine($"Min byte: {float.MinValue} max: {float.MaxValue}");
			Console.WriteLine($"Min byte: {double.MinValue} max: {double.MaxValue}");
			Console.WriteLine($"Min byte: {decimal.MinValue} max: {decimal.MaxValue}");


			Console.WriteLine("---------------LOGICAL-----------");
			bool boolean;
			Console.WriteLine("TRUE: " + bool.TrueString + ", FALSE: " + bool.FalseString);


			Console.WriteLine("---------------STRINGS-----------");
			char c1 = 'a';  //'\x006A',
							//'\u006A',
							//(char)106
			char c12 = 'j';


			string s12 = "as";



			Console.WriteLine("-----Oprations----");

			Console.WriteLine("Unary");
			int n1 = -1;
			int p1 = 1;
			Console.WriteLine(+n1);
			Console.WriteLine(-p1);

			Console.WriteLine("INCREAMENT");
			int a = 6;

			Console.WriteLine(++a); // 7 7 7 7
			Console.WriteLine(a++); // 6 7 7 7
			Console.WriteLine(--a); // 5 6 5 7
			Console.WriteLine(a--); // 6 5 6 7
			Console.WriteLine(a);

			a++;

			var bB = 10;
			bB = ++bB + bB-- + bB;
			Console.WriteLine(bB); // 20

			int b = 6;
			Console.WriteLine(--b + b--);// 10 11 
			Console.WriteLine(b);

			//int a1 = 7;
			//int a2 = 2;
			//Console.WriteLine("/: " + 7 / 2);
			//Console.WriteLine("%: " + 7 % 2);

			float f_1 = 0.2f;
			float f_2 = 0.1f;

			double d_1 = 0.12;

			decimal dec = 12.12m;

			int a11 = 4; // 1000
			Console.WriteLine(a11 << 1);

			int a12 = 1; // 0001
			Console.WriteLine(a12 >> 3);

			int b12 = int.MaxValue;
			Console.WriteLine(b12 + 1);


			int b13 = 5; // 0101
			int b14 = 3; // 0011

			Console.WriteLine(b13 & b14); // 0001 // 1
			Console.WriteLine(b13 | b14); // 0111 // 7
			Console.WriteLine(b13 ^ b14); // 0110 // 6


			bool bool1 = true;
			bool bool2 = true;

			Console.WriteLine("bool1" + !bool1);
			Console.WriteLine("bool2" + !bool2);

			Console.WriteLine(bool1 && bool2); // false && false = false
			Console.WriteLine(bool1 || bool2); // 
			Console.WriteLine(bool1 ^ bool2);

			int iD = 0;
			byte bD = 0;
			float fD = 0.0f;
			double dD = 0.0;
			decimal mD = 0.0m;
			char cD = '\0';
			string sD = null;

			Console.WriteLine("----------Math---------");
			var q = -12;
			var qResult = Math.Abs(q);

			var floatingNumber = 5.5;

			Console.WriteLine(qResult);
			Console.WriteLine("ABS: " + Math.Abs(q));
			Console.WriteLine("MAX: " + Math.Max(12, 234));
			Console.WriteLine("MIN: " + Math.Min(12, 234));
			Console.WriteLine("Acos: " + Math.Acos(1));
			Console.WriteLine("Cos: " + Math.Cos(1));
			Console.WriteLine("Sin: " + Math.Sin(1));
			Console.WriteLine("Sqrt: " + Math.Sqrt(1));
			Console.WriteLine("Sqrt minus: " + Math.Sqrt(-1));
			Console.WriteLine("Cbrt: " + Math.Cbrt(27));
			Console.WriteLine("Ceiling: " + Math.Ceiling(floatingNumber));
			Console.WriteLine("Floor: " + Math.Floor(floatingNumber));
			Console.WriteLine("Round: " + Math.Round(floatingNumber));
			Console.WriteLine("Truncate: " + Math.Truncate(floatingNumber));
			Console.WriteLine("Log2: " + Math.Log2(100));
			Console.WriteLine("Log10: " + Math.Log10(1000));
			Console.WriteLine("PI: " + Math.PI);


			Console.WriteLine("----DateTime----");
			DateTime dateTime = new DateTime();
			Console.WriteLine(dateTime);

			DateTime dateTimeNow = DateTime.Now;
			Console.WriteLine(dateTimeNow);

			DateTime dateTimeToday = DateTime.Today;
			Console.WriteLine(dateTimeToday);

			DateTime dateTimeUtc = DateTime.UtcNow;
			Console.WriteLine(dateTimeUtc);


			Console.WriteLine(DateTime.Now.Second);
			Console.WriteLine(DateTime.Now.Minute);
			Console.WriteLine(DateTime.Now.Day);
			Console.WriteLine(DateTime.Now.Month);
			Console.WriteLine(DateTime.Now.Year);
			Console.WriteLine(DateTime.Now.DayOfYear);
			Console.WriteLine(DateTime.Now.DayOfWeek);


			var tS = TimeSpan.FromSeconds(300);
			Console.WriteLine(tS);
			var tS2 = TimeSpan.FromMinutes(5);
			Console.WriteLine(tS2);


			var mountAgo = DateTime.Now - TimeSpan.FromDays(30);
			Console.WriteLine(mountAgo);
		}
	}
}