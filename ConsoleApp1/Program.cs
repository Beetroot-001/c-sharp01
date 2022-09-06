namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
      /*Define several variables in your program (byte, short, int, long, bool, char, float, double, decimal, string) 
      and write to console the result of addition, subtraction, multiplication of several of them.*/

      Console.WriteLine($"-----------addition");

      string name = "Vika";
      int a = 23;
      byte c = 3;
      double age = c + (a - 0.5);
      decimal height = 1.711M;
      Console.WriteLine($"Enter your name: {name}");
      Console.WriteLine($"Enter your age: {age}");
      Console.WriteLine($"Enter your height: {height}m");

      Console.WriteLine($"-----------substraction");

      int g = 20;
      int b = 5;
      float min = g - b++;

      Console.WriteLine(min);

      Console.WriteLine($"-----------muiltiplication");

      Console.WriteLine(min++ - g * b);

      /*Write to console result of several math functions:
     -6*x^3+5*x^2-10*x+15
     abs(x)*sin(x)
     2*pi*x
     max(x, y)*/
     long x = 1;
     int y = 2;

     Console.WriteLine($"-----------'Calculate: -6*x^3+5*x^2-10*x+15'");
     Console.WriteLine(-6*x^3+5*x^2-10*x+15);

     Console.WriteLine($"-----------'Calculate: abs(x)*sin(x)'");
     Console.WriteLine(Math.Abs(x)*Math.Sin(x));

     Console.WriteLine($"-----------'Calculate: 2*Math.PI*x'");
     Console.WriteLine(2*Math.PI*x);

     Console.WriteLine($"-----------'Calculate: max(x, y)'");
     Console.WriteLine($"{long.MaxValue}, {int.MaxValue}");
		}
	}
}