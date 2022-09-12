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
            int sum = 0;
                if (x != y)
                {
                 for(int i =x;i<=y;i++)
                    {
                        sum += i;

                    }
                    Console.WriteLine($"The sum between {x} and {y} is {sum}");
                    Console.WriteLine(">> Press the L to left the program\n>> Press Enter to continue");
                    if(Console.ReadLine() == "L")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"The sum between {x} and {y} is {x}");
                    Console.WriteLine(">> Press the L to left the program\n>> Press Enter to continue");
                    if (Console.ReadLine() == "L")
                    {
                        break;
                    }
                }
                

            }
        }
       

    }
}