namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{

            int[,] array2d = new int[,] 
            { 
                { 10, 5, 10 }, 
                { 12, 2, 10 }
            };

            for (int element = 0; element < 3; element++)
            {
                int x = (array2d[0, element]);
                int y = (array2d[1, element]);

                Console.WriteLine(x);
                Console.WriteLine(y);
                Console.WriteLine("---");

                List<int> list = new List<int>();

                for (int s = Math.Min(x,y); s <= Math.Max(x, y); s++)
                {
                    list.Add(s);
                    continue;
                }
                list.ForEach(Console.WriteLine);
                Console.WriteLine("--------");
                Console.WriteLine("sum of all values: " + list.Sum());
                Console.WriteLine("-------------------------------------");
            }

            int c = 7;
            int t = 5;
            Console.WriteLine(c);
            Console.WriteLine(t);

            (c, t) = (t, c);
            Console.WriteLine(c);
            Console.WriteLine(t);
        }
    }
}