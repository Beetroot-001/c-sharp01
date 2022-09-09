namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            /////////Regular Homerwork//////////////////
            Console.WriteLine("///////////Regular Homerwork//////////////////");

            bool check = true;
            while (check)
            {
                int sum = 0;
                int x = 0;
                int y = 0;

                Console.WriteLine("Enter the value for X");
                check = Int32.TryParse(Console.ReadLine(), out x);

                if (!check)
                {
                    Console.WriteLine("Invalid input");
                    break;
                }

                Console.WriteLine("Enter the value for Y");
                check = Int32.TryParse(Console.ReadLine(), out y);

                if (!check)
                {
                    Console.WriteLine("Invalid input");
                    break;
                }

                if (x > y)           ///I'm not sure, but I think this swap should be implemented, otherwise if the first number is larger, there will be a mistake
                {
                    int temp = x;
                    x = y;
                    y = temp;
                }

                for (int i = x; i <= y; i++)
                {
                    sum += i;
                }
                Console.WriteLine($"The result is {sum}");

                int sum2 = (x + y) * ((y - x) + 1) / 2;
                Console.WriteLine($"The result if you use arithmetic progression instead of loop is {sum2}");

                Console.WriteLine("Do another calculation? y/n");

                switch (Console.ReadLine())
                {
                    case "y":
                        check = true;
                        Console.Clear();
                        break;

                    default:
                        check = false;
                        break;
                }
            }






            //////////SUPER EXTRA HOMEWORK 1////////////
            Console.WriteLine("/////////SUPER EXTRA HOMEWORK 1//////////////");
            Console.WriteLine("Solution #1");

            int x1 = 5;
            int y1 = 7;

            Console.WriteLine($"Initial x value: {x1}, initial y value: {y1}");
            x1 = x1 + y1;
            y1 = x1 - y1;
            x1 = x1 - y1;

            Console.WriteLine($"Swapped x value: {x1}, swapped y value: {y1}");


            Console.WriteLine("\nSolution #2");
            Console.WriteLine($"Initial x value: {x1}, initial y value: {y1}");
            static void Swap(ref int x, ref int y)
            {
                int temp = x;
                x = y;
                y = temp;
            }
            Swap(ref x1, ref y1);
            Console.WriteLine($"Swapped x value: {x1}, swapped y value: {y1}");




            ////////////////////SUPER EXTRA HOMEWORK 2///////////////////
            Console.WriteLine("///////////SUPER EXTRA HOMEWORK 2/////////////////");

            Console.WriteLine("/////////Solution #1. This can work with numbers numbers that do not exceed the value of 113////////////");

            int a = 1;
            int b = 50;

            for (int i = 2; i <= b; i++)
            {
                bool check1 = true;

                if (i % 2 == 0 && i > 2)
                {
                    continue;
                }

                for (int j = 2; j < 9; j++)
                {
                    if (i % j == 0 && j != i)    /*check if number can be divided by number in a range from 1 to 9, except itself. This range will work for numbers that do not exceed the value of 113*/
                    {
                        check1 = false;
                        break;
                    }
                }

                if (check1 == true)
                {
                    Console.WriteLine(i);
                }

            }

            Console.WriteLine("///////////Solution #2. This can work with numbers bigger than 113, probably any/////////////");

            for (int i = 2; i <= b; i++)
            {
                bool check2 = true;

                if (i % 2 == 0 && i > 2)
                {
                    continue;
                }

                for (int j = 2; j < b / 3; j++) /*increase te number of checkings, but now it will work for bigger values*/
                {
                    if (i % j == 0 && j != i)
                    {
                        check2 = false;
                        break;
                    }
                }

                if (check2 == true)
                {
                    Console.WriteLine(i);
                }

            }



        }
    }
}