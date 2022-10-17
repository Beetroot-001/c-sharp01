namespace ConsoleApp1
{
	public class Board
	{
		public int Size { get; private set; }
		public Snake Snake { get; private set; }
		public Fruit Fruit { get; private set; }

		private System.Timers.Timer _timer;

		public Board(int size)
		{
			Snake = new Snake();
			Fruit = Fruit.CreateFruit(size);
			Size = size;

			_timer = new System.Timers.Timer(1000);

			_timer.Elapsed += Snake.Move;

		}

		public void Render()
		{
			_timer.Start();

			// board
			Console.ForegroundColor = ConsoleColor.Red;
			for (int i = 0; i < Size; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write("#");

				Console.SetCursorPosition(i, 0);
				Console.Write("#");

				Console.SetCursorPosition(i, Size - 1);
				Console.Write("#");

				Console.SetCursorPosition(Size - 1, i);
				Console.Write("#");
			}

			// snake
			Console.ForegroundColor = ConsoleColor.Green;
			for (int i = 0; i < Snake.Body.Count; i++)
			{
				Point item = Snake.Body[i];
				Console.SetCursorPosition(item.X, item.Y);
				Console.Write("*");
			}

			// fruit
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.SetCursorPosition(Fruit.Location.X, Fruit.Location.Y);
			Console.Write("@");
		}
	}
}
