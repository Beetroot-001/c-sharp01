using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(string.Join(',', args));

			Console.WriteLine("*************");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*		   *");
			Console.WriteLine("*************");

			int b;
			int c = 0;

			string s = "origin";
			var t = Method1(out b, ref c, s);

			Console.WriteLine("Out>: " + b);
			Console.WriteLine("Ref>: " + c);
			Console.WriteLine("Str ref>: " + s);
			Console.WriteLine("Res> " + t);

			int qw1 = 0;
			int qw2 = 5;
			MethodWithinRef(ref qw1);
			MethodWithoutRef(qw2);

			Console.WriteLine("MethodWithinRef " + qw1);
			Console.WriteLine("MethodWithoutRef " + qw2);

			int.TryParse("7", out qw2);

			int y;
			var result = TryParse("asv", out y);

			var result1 = TryParse("x", out int u);

			Console.WriteLine($"Result: {result}, x: {y}");
			Console.WriteLine($"Result: {result1}, x: {u}");


			Empty();

			int number = 1;
			NonEmpty(number,
				includeRequired: true);

			Params("", true, 1, 2, 3, 4, 5, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4);


			dynamic a = (short)5;

			Overloaded("asd");
			Overloaded(4);
			Overloaded(a);

			Console.WriteLine("---");
			Console.WriteLine(8);
			Console.WriteLine("---");

			//Recursion(1);


			Console.WriteLine("factorial");
			var res = GetFactorialOf(100);
			Console.WriteLine(res);

			Console.WriteLine("rec factorial");
			var res2 = GetFactorialRecursionOf(1);
			Console.WriteLine(res2);

			var resObj = new object();
			var newObj = MethodObj(resObj);

			Console.WriteLine($"Equals : {newObj == resObj}");

			Console.ReadLine();
		}

		static int Method1(out int b, ref int x, string str)
		{
			b = 7;
			x = 10;

			str += " changed";
			return 45;
		}

		static int MethodWithinRef(ref int x)
		{
			//x = 10;

			return 45;
		}

		static int MethodWithoutRef(int x)
		{
			x = 10;

			return 45;
		}

		static bool TryParse(string str, out int x)
		{
			x = -1;

			if (str == "x")
			{
				x = 10;
				return true;
			}

			return false;
		}

		static void Empty()
		{
			Console.WriteLine("Empty");
		}

		static void NonEmpty(int d1, bool includeRequired = false)
		{
			Console.WriteLine($"D: {d1}");
		}

		static void Params(string s, bool includeRequired = false, params object[] arra)
		{
			for (int i = 0; i < arra.Length; i++)
			{
				Console.WriteLine(arra[i]);
			}
		}

		static void Overloaded(int a)
		{
			Console.WriteLine("Int a");
		}

		static void Overloaded(double a)
		{
			Console.WriteLine("Double a");
		}

		static void Overloaded(string a)
		{
			Console.WriteLine("String a");
		}

		static void Overloaded(object a)
		{
			Console.WriteLine("Object a");
		}

		static void Overloaded(int a, string b)
		{
			Console.WriteLine("int a, string b");
		}

		static void Recursion(int b)
		{
			if (b == 10)
				return;

			Console.WriteLine("WELCOME");

			Recursion(b);
		}

		static long GetFactorialOf(int n)
		{
			long res = 1;
			for (int i = 1; i <= n; i++)
			{
				res = res * i;
			}

			object a = new object();
			var ob = a ?? new object();

			return res;
		}

		static long GetFactorialRecursionOf(int n)
		{
			if (n == 1)
				return 1;

			return n * GetFactorialRecursionOf(n - 1);
		}

		static int Method(int num)
		{
			return num > 0 ? num + Method(num - 1) : 0;
		}
		static object MethodObj(object num)
		{
			num = new object();

			return num;
		}
	}
}