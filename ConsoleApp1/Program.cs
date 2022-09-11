namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Cross
			Cross(10);

			//Example for  max value among all the parameters
			
			Maximum(3,2);

			int[] mass = {1,5,3};
			Maximum(mass);

			// Min value …

			int[] massmin = {-1,6,8};
			Minimum(massmin);
			Console.ReadLine();

			//out
			bool sumResult;
			TrySumIfOdd(4, 5, out sumResult);
			Console.WriteLine(sumResult);
			Console.ReadLine();

			//recursion
			Recrec("ma",2);
			Console.ReadLine();

		}

		//Method that will return max value among all the parameters
			static int Maximum(int a, int b)
			{
				int c;
				c = a > b ? a:b;
				Console.WriteLine($"Maximum is {c}");
				return c;
			}

			static int Maximum(params int[] arr)
			{
				int c = arr[0];
				foreach (var i in arr)
				{
					c = c < i ? i : c;
				}
				Console.WriteLine($"Maximum is {c}");
				return c;
			}


		// min value …

			static int Minimum(int a, int b)
			{
				int c;
				c = a < b ? a:b;
				Console.WriteLine($"Minimum is {c}");
				return c;
			}

			static int Minimum(params int[] arr)
			{
				int c = arr[0];
				foreach (var i in arr)
				{
					c = c < i ? c : i;
				}
				Console.WriteLine($"Minimum is {c}");
				return c;
			}

		//Method TrySumIfOdd that accepts 2 parameters
		//and returns true if sum of numbers between inputs is odd,
		//otherwise false, sum return as out parameter

		static void TrySumIfOdd(int a, int b, out bool sum)
		{
			sum  = true;
			sum = (a+b)%2 == 0 ? false: true; 
		}

		//Define and call with different parameters next methods:
        //Method Repeat that will accept string X and number N
		//and return X repeated N times
		//(e.g. Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)

		static void Recrec(string x, int n)
		{
			if(n == 0 || n < 0)
				return;
			
			Console.Write(x);
			Recrec(x, n-1);	
		}


		//Cross
		static void Cross(int n)
		{
			for (int i = 1; i < n; i++)
				{
					for (int j = 1; j < n; j++)
						{
							if(i == j)
							Console.Write("*");
							else
						Console.Write(" ");
						}	
				
					for (int k = n-1 ; k > 0; k--)
						{
							if(i == k)
							Console.Write("*");
							else
						Console.Write(" ");
						}	
					Console.WriteLine();
				}


			for (int i = n-1; i > 0; i--)
				{
					for (int j  = 1; j < n; j++)
						{
							if(i == j)
							Console.Write("*");
							else
						Console.Write(" ");
						}

				for (int k  = n-1; k >0; k--)
						{
							if(i == k)
							Console.Write("*");
							else
						Console.Write(" ");
						}	
					Console.WriteLine();
				
				}			
		}
	

}
}

	