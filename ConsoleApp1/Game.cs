namespace ConsoleApp1
{
    public class Game
    {
        static Board board;
        public Game()
        {

        }

        public static void Start()
        {            
            board = new();
            Board.DrawBoard();
            Board.fruit.CreateFruit();
            Task.Delay(Timeout.Infinite).Wait();
        }

        public static void Lose()
        {
            board.Stop();
            Console.Clear();
            Direction.eDirection = Direction.EDirection.East;
            Board.DrawBoard();
            LeaderBoard.AddResult(Snake.score);
            Menu.DrawMenu();
        }

    }
}