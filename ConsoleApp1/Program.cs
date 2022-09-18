using System.Globalization;
using System.Text;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			char c = '\0';
			Char c1;

			c = '\u0001';
			c = '\x123';

			CheckCharacter(c);
			CheckCharacter('1');
			CheckCharacter('\n');
			CheckCharacter(' ');
			CheckCharacter('a');
			CheckCharacter('$');
			CheckCharacter('\0');
		}

		public static void CheckCharacter(char c)
		{
			Console.WriteLine($"Char: {c}");

			Console.WriteLine($"IsAscii: {char.IsAscii(c)}");
			Console.WriteLine($"IsControl: {char.IsControl(c)}");
			Console.WriteLine($"IsDigit: {char.IsDigit(c)}");
			Console.WriteLine($"IsLetter: {char.IsLetter(c)}");
			Console.WriteLine($"IsLetterOrDigit: {char.IsLetterOrDigit(c)}");
			Console.WriteLine($"IsLower: {char.IsLower(c)}");
			Console.WriteLine($"IsNumber: {char.IsNumber(c)}");
			Console.WriteLine($"IsPunctuation: {char.IsPunctuation(c)}");
			Console.WriteLine($"IsSymbol: {char.IsSymbol(c)}");
			Console.WriteLine($"IsUpper: {char.IsUpper(c)}");
			Console.WriteLine($"IsSeparator: {char.IsSeparator(c)}");
			Console.WriteLine($"IsWhiteSpace: {char.IsWhiteSpace(c)}");
			Console.WriteLine($"ToUpper: {char.ToUpper(c)}");
			Console.WriteLine($"ToUpper: {char.ToUpperInvariant(c)}");
			Console.WriteLine($"ToUpper: {char.ToLower(c)}");
			Console.WriteLine($"ToUpper: {char.ToLowerInvariant(c)}");


			char a = 'a';
			char b = 'b';
			Console.WriteLine($"a == b {a == b}");
			Console.WriteLine($"a != b {a != b}");
			Console.WriteLine($"a > b {a > b}");
			Console.WriteLine($"a < b {a < b}");
			Console.WriteLine('a' > 'A');

			Console.WriteLine($"a, b: {('e' + 1).CompareTo('a')}");
			Console.WriteLine($"a, a {'a'.CompareTo('a')}");
			Console.WriteLine($"A, a {'A'.CompareTo('a')}");


			string str = null;
			Console.WriteLine(str);

			string str1 = new string("asd");
			Console.WriteLine(str1);

			string str2 = "asd";

			string empty = "";
			string otherEmpty = string.Empty;

			Console.WriteLine(empty == otherEmpty);

			string str4 = "hello world";
			string str5 = "hello";
			string str51 = "hello";
			string str6 = " world";
			string str7 = str5 + str6;

			Console.WriteLine(str5 == str51);
			Console.WriteLine(object.ReferenceEquals(str5, str51));

			Console.WriteLine(str4 == str7);
			Console.WriteLine(object.ReferenceEquals(str4, str7));

			Console.WriteLine(string.Compare(str5, str51));
			Console.WriteLine(string.Compare(str4, str51));
			Console.WriteLine(string.Compare("aaaa", "aaa"));

			//CultureInfo.CurrentCulture = new CultureInfo("ca-FR");

			//Console.WriteLine(23.5);
			Console.WriteLine(string.Equals("aaaa", "aaAa", StringComparison.CurrentCulture));

			string newStr = "qwe" + "qwe";
			string newStr2 = string.Concat("qwe", "qwe");

			string newStr3 = string.Format("ToUpper: {0}, {1,-10}, {2}, {3:D}", char.ToLower('f'), 5000000, "as", DateTime.Now);
			Console.WriteLine(newStr3);

			Console.WriteLine($"asdasdasd {newStr3}");


			Console.WriteLine(str7 == str4);
			Console.WriteLine(Object.ReferenceEquals(str7, str4));
			var internedString = string.Intern(str7);

			Console.WriteLine(internedString == str4);
			Console.WriteLine(Object.ReferenceEquals(internedString, str4));

			Console.WriteLine(string.IsNullOrEmpty(null));
			Console.WriteLine(string.IsNullOrEmpty(""));
			Console.WriteLine(string.IsNullOrEmpty("s"));

			Console.WriteLine(string.IsNullOrWhiteSpace(null));
			Console.WriteLine(string.IsNullOrWhiteSpace("\n"));
			Console.WriteLine(string.IsNullOrWhiteSpace(" "));
			Console.WriteLine(string.IsNullOrWhiteSpace("    \n      "));

			string helloworld = string.Join('|', "hello", " world");
			Console.WriteLine(helloworld);


			string res = "";

			for (int i = 0; i < 200; i++)
			{
				res = res + i;
			}
			Console.WriteLine(res.ToString());


			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 200; i++)
			{
				stringBuilder.Append(i);
			}

			Console.WriteLine(stringBuilder.ToString());

			string s = "a";
			string s1 = "b";


			Console.WriteLine(s.Length);

			Console.WriteLine(s[0]);

			string resS = (string)s.Clone();
			res = s;

			Console.WriteLine(resS == s);
			Console.WriteLine(string.ReferenceEquals(resS, s));

			string s3 = "dfdfvbcadfdf";
			char[] charArray = new char[s3.Length];
			s3.CopyTo(0, charArray, 0, s3.Length);

			Console.WriteLine();


			Console.WriteLine(s3.Contains("A", StringComparison.OrdinalIgnoreCase));

			Console.WriteLine(s3.EndsWith("abcd"));
			Console.WriteLine(s3.StartsWith("aa"));
			Console.WriteLine("Substring " + s3.Substring(s3.Length - 2));
			Console.WriteLine("Substring " + s3.Substring(s3.Length - 2));

			Console.WriteLine(s3.LastIndexOf("vBb", StringComparison.OrdinalIgnoreCase));
			Console.WriteLine(s3.IndexOf('a'));

			Console.Write(s.PadRight(10));
			Console.Write("1");
			Console.WriteLine();
			Console.WriteLine(s3.Replace("dfd", "!!!!!!"));

			string s4 = "          a.s.f.g..g.           ";
			var resArray = s4.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			Console.Write("resArray" + resArray);
			Console.Write(s4.Trim());

			object obj = new object();
			obj.ToString();
			int t = 5;
			t.ToString();

			float[] ints = new float[t];
			Console.WriteLine(ints.ToString());
			Console.WriteLine(new Program().ToString());
		}
	}
}