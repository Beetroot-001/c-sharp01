namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//SUPER EXTRA HOMEWORK 1
			int x = 7;
			int y = 5;
			Console.WriteLine($"Start: x = {x}, y = {y}");
			
			int[ ] num = new int[] {x, y};
			y = num[0];
			x = num[1];
			Console.WriteLine($"Firts variant solution: x = {x}, y = {y}");
			Console.ReadLine();

			(x,y) = (y,x);
			Console.WriteLine($"And back: x = {x}, y = {y}");
			Console.ReadLine();


			//SUPER EXTRA HOMEWORK 2
			int a = 1;
			int b = 5;
			for (int i = a+1; i < b+1; i++)
			{
				if(i ==2 || i%2 != 0)
				{
					Console.WriteLine(i);
				}	
			}
			Console.ReadLine();


			//Create a program that will start with declaration of two constants (X and Y)
			//and will count the sum of all numbers between these constants.
            //If they are equal then sum should be one of them

			int xx = 1;
			int yy = 3;
			int sum = 0;
			for (int i = (xx-1); i < (yy+1); i++)
			{
				if(xx != yy)
				{
					sum = sum + i;
				}
				else
				{
					sum = xx;
				}
			
			}

			Console.WriteLine($"Sum is {sum}");
			Console.ReadLine();


			//Read values of X and Y from the console.
            //If output is invalid - write to console Invalid input and exit the program.

			Console.WriteLine("Perform input from console HW");
			string keyboard = Console.ReadLine();
			int numberrr;

			switch (int.TryParse(keyboard, out numberrr))
			{
				case true:
					Console.WriteLine($"numberrr is: {numberrr}");
					break;
				default:
					Console.WriteLine("Invalid input");
					break;
			}

			Console.ReadLine();
		}
	}
}