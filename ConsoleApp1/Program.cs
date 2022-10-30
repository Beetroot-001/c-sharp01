
using System.Timers;

namespace ConsoleApp1
{
    internal class Program
    {
        static System.Timers.Timer timer = new System.Timers.Timer(200);

        static int x = 60;
        static int y = 20;
        public static int speed { get; set; } = 200;

        static Snake snake = new Snake(x, y, '*');
        static Fruit fruit = new Fruit(x, y, '@');
        static Board board = new Board(x, y, snake, fruit);

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            fruit.NewFruit();

            board.DisplayScore();

            snake.EatingFruit += board.DisplayScore;

            Console.ReadKey();


            timer.Elapsed += Loop;
            timer.Start();


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(false);
                    snake.MoveOfSnake(consoleKeyInfo);
                }
            }
        }

        static void Loop(object? sender, ElapsedEventArgs e)
        {
            snake.GetNextMove();

            if (snake.IsHittingWall())
            {
                timer.Stop();
                Console.WriteLine("Game Over");
            }

            else if (snake.IsHittingBody())
            {
                timer.Stop();
                Console.WriteLine("Game Over");
            }

            snake.Eat(fruit);
        }
    }
}