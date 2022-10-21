
namespace ConsoleApp1
{
    internal class Program
    {
        static Timer timer;

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

            timer= new Timer(Loop, null, 0, speed);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    snake.MoveOfSnake(consoleKeyInfo);
                }
            }
        }

        static void Loop(object obj)
        {
            snake.GetNextMove();

            if (snake.IsHittingWall())
            {
                timer.Change(0, Timeout.Infinite);
                Console.WriteLine("Game Over");
            }

            else if (snake.IsHittingBody())
            {
                timer.Change(0, Timeout.Infinite);
                Console.WriteLine("Game Over");
            }

            snake.Eat(fruit);
        }
    }
}