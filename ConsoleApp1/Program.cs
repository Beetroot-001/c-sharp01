namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			 /* Create a program that will start with declaration of two constants(X and Y) and will 
                   count the sum of all numbers between these constants.If they are equal then sum should be one of them

                 Example:

                 X = 10
                 Y = 12
                 Sum = 10 + 11 + 12 = 33

             */

                int x;
                int y;
                int sumCaunt=0;
                // ввід діаразону
                while (true)
                {
                    Console.Write($"Enter naumber: max value {int.MaxValue}, min value{int.MinValue} x =\t");
                    if (int.TryParse(Console.ReadLine(), out x))
                        break;
                    Console.WriteLine("Incorrectly entered number, try again");
                }
                while (true)
                {
                    Console.Write($"Enter naumber: max value {int.MaxValue}, min value{int.MinValue} y =\t");
                    if (int.TryParse(Console.ReadLine(), out y))
                        break;
                    Console.WriteLine("Incorrectly entered number, try again");
                }

                Console.WriteLine($"x = {x}\ny = {y}\n--------SUM----------");
                
                for (int i = Math.Min(x,y); ; i++)
                {
                    if (x==y)
                    {
                        Console.WriteLine($"{x}+{y}={x+y}");
                        break;
                    }

                    Console.Write(i);
                    sumCaunt += i;

                    if (i == Math.Max(x, y))
                    {
                        Console.Write($"={sumCaunt}");
                        break;
                    }
                    Console.Write("+");
                }
                //
                /*SUPER EXTRA HOMEWORK 1

                There are 2 variables.

                int x = 7;
                int y = 5;
                The task is to swap values for that variables. The result of x should be 5 and y - 7.

                SUPER EXTRA HOMEWORK 2

                Find prime numbers in range a..b

                Example: 

                a=1;
                b=5;
                Output: 2,3,5
                */

                Console.WriteLine("-----------SUPER EXTRA HOMEWORK 1----------");
                x = x + y;//7+3 = 10
                y = x - y;//10-3=7
                x= x - y;//10-7=3

                Console.WriteLine($"x = {x}\ny = {y}");

                Console.WriteLine("-----------SUPER EXTRA HOMEWORK 2----------");

                int a;
                int b;
                // вводжу діапазон
                while (true)
                {
                    Console.Write($"Enter naumber: max value {int.MaxValue}, min value{int.MinValue} a =\t");
                    if (int.TryParse(Console.ReadLine(), out a))
                        break;
                    Console.WriteLine("Incorrectly entered number, try again");
                }
                while (true)
                {
                    Console.Write($"Enter naumber: max value {int.MaxValue}, min value{int.MinValue} b =\t");
                    if (int.TryParse(Console.ReadLine(), out b))
                        break;
                    Console.WriteLine("Incorrectly entered number, try again");
                }
                // перебор діапазону
                for (int naubInRange = Math.Min(a,b); naubInRange <= Math.Max(a,b); naubInRange++)
                {
                    bool checkNaubBool = true;
                    for (int j = 2; j < naubInRange; j++)// перевірка кожного числа з діапазону
                    {
                        if (naubInRange%j==0)
                            checkNaubBool = false;
                    }

                    if (checkNaubBool)
                        Console.Write($"{naubInRange}\t");
                }
                Console.ReadLine();
		}
	}
}