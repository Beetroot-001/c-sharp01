namespace ConsoleApp1
{
	public class Fruit
	{
		public Point Location { get; private set; }

		private Fruit()
		{

		}

		public static Fruit CreateFruit(int boardSize)
		{
			var rand = new Random((int)DateTime.Now.Ticks);

			return new Fruit
			{
				Location = new Point(rand.Next(4, boardSize - 2), rand.Next(1, boardSize - 2)),
			};
		}
	}
}
