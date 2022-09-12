using System;

public static class StringConversion
{
    public static void Main()
    {
       
        //homework task

        for (; ; )
        {
            Console.WriteLine("\nEnter the value of x");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of y");
            int y = Convert.ToInt32(Console.ReadLine());
            
            { 
            int sum = x + y;
                if (x == y)
                {
                    Console.WriteLine($"The Sum = {x}\n>>To left Enter L\n >>To continue PRESS --enter--");
                    if (Console.ReadLine() == "L")
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine($"The Sum = {sum=x+y}\n>>To left Enter L\n>>To continue PRESS --enter--");
                    if (Console.ReadLine() == "L")
                    {
                        break;
                    }
                }

            }
        }
       

    }
}