namespace ConsoleApp1
{
	public class Game
	{
		public Board Board { get; private set; }
		public Game(int size = 15)
		{
			Board = new Board(15);
		}

		public void StartGame()
		{
			Board.Render();
		}
	}
}
