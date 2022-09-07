namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //без 3 змінної обміняти місцями значення 2 інтів
            int x = 53;
            int y = 1;
            Console.WriteLine($"x = {x}\ny = {y}");
            intSwitcher(ref x, ref y);
            Console.WriteLine($"x = {x}\ny = {y}");
            //---//

            string input = "";
            while (true)
            {
                x = 0;
                y = 0;
                Console.WriteLine("\nВедіть 2 числа. Для виходу введіть x");
                Console.WriteLine("Ведіть 1 число");
                input = Console.ReadLine();

                if (input.Contains("x") || input.Contains("х")) break;

                if(!int.TryParse(input, out x))
                {
                    Console.WriteLine("Помилка вводу. спробуйте ще раз.");
                    continue;
                }

                Console.WriteLine("Ведіть 2 число");
                input = Console.ReadLine();
                if (input.Contains("x") || input.Contains("х")) break;

                if (!int.TryParse(input, out y))
                {
                    Console.WriteLine("Помилка вводу. спробуйте ще раз.");
                    continue;
                }

                if(y < x) intSwitcher(ref x, ref y);

                int summ = x;
                if (x != y)
                {
                    for (int i = x+1; i <= y; i++)
                    {
                        summ += i;
                    }
                }
                Console.WriteLine($"Результат: {summ}");
            }
            Console.WriteLine("ну всьо... приїхали!");
            Console.ReadLine();
        }

        static void intSwitcher(ref int x, ref int y)
        {           
            x = int.Parse(y.ToString() + x.ToString());
            y = int.Parse(x.ToString().Substring(y.ToString().Length));
            x = int.Parse(x.ToString().Substring(0, x.ToString().Length - y.ToString().Length));
        }
    }
}