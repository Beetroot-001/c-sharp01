namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
 Console.WriteLine("1. Костиль \n 2. Формула \n 3.Свап змінних \n 4.Prime Number" );
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("x = ");
            x = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("y = ");
            y = Int32.Parse(Console.ReadLine());
            Console.Clear();
            switch (n) {  
                case 1:
            

            int result = 0;
                    if (x > y)
                    {

                        //Console.Write(y);
                        for (int i = y; i <= x; i++)
                        {

                            if (i < x)
                            {
                                Console.Write(i + "+");
                                result += i;
                            }
                            else if (i == x)
                            {
                                result += i;
                                Console.WriteLine(i + "=" + result);
                            }
                        }

                    }
                    else if (y > x)
                        for (int i = x; i <= y; i++)
                        {

                            if (i < y)
                            {
                                Console.Write(i + "+");
                                result += i;
                            }
                            else if (i == y)
                            {
                                result += i;
                                Console.WriteLine(i + "=" + result);
                            }

                            else if (x == y)
                                Console.WriteLine(x);
                        }
                    break;
                    case 2:

                    if (x > y)
                    {
                        int d = x - y;
                        result = ((2 * y + 1 * (d - 1) / 2) * d);
                        Console.WriteLine(result);
                    }
                    else if (y > x)
                    {
                        int d = y - x;
                        result = ((2 * x + 1 * (d - 1) / 2) * d);
                        Console.WriteLine(result);
                    }
                    else if (x == y)
                        Console.WriteLine(x);
                    break;
                case 3: 
                        int x1 = 7;
                    int y1 = 5;
                    Console.WriteLine(x1 +y1);
                    (x1, y1) = (y1, x1);
                    Console.WriteLine("*~MAGIC~*");
                    Console.WriteLine(x1 + y1);
                    break;
                case 4:
                    
                    while (x >= y)
                    {
                        y++;
                        if (y == 2 ||  y == 3 || y == 5)
                            Console.WriteLine(y);
                        if (y > 1 && y % 2 != 0 && y % 3 != 0 && y % 5 != 0)
                        {

                            Console.WriteLine(y);
                        }
                        else continue;
                    }
                                        
                    while (y >= x)
                    {
                        x++;
                        if (x == 2 || x == 3 || x == 5)
                            Console.WriteLine(x);
                        if (x > 1 && x % 2 != 0 && x % 3 != 0 && x % 5 != 0)
                        {

                            Console.WriteLine(x);
                        }
                        else continue;
                    }
                    break;
		}
	}
}
