using System.Timers;

namespace ConsoleApp1
{
	public class Snake
	{
		public List<Point> Body { get; private set; }

		public int LastMoveKey { get; set; } = 39;
		public DateTime LastMovePressed { get; set; } = DateTime.Now;
		public bool FruitGotted { get; set; } = false;

		public Snake()
		{
			Body = new List<Point>
			{
				new Point(1,1),
				new Point(2,1),
				new Point(3,1),
			};
		}

		public void Move(object? sender, ElapsedEventArgs e)
		{
			if (Console.KeyAvailable)
			{
				var key = Console.ReadKey(true);
				List<int> availableKeys = new()
				{
					65,
					87,
					68,
					83,
					37,
					38,
					39,
					40
				};
				if (availableKeys.Contains((int)key.Key) && (DateTime.Now - LastMovePressed).Seconds >= 1)
				{
					LastMoveKey = (int)key.Key;
					LastMovePressed = DateTime.Now;
				}
			}

			Point p = new Point(Body.Last().X + 1, Body.Last().Y);
			switch (LastMoveKey)
			{
				case 37:
				case 65:
					{
						p = new Point(Body.Last().X - 1, Body.Last().Y);
					}
					break;
				case 38:
				case 87:
					{
						p = new Point(Body.Last().X, Body.Last().Y - 1);
					}
					break;
				case 39:
				case 68:
					{
						p = new Point(Body.Last().X + 1, Body.Last().Y);
					}
					break;
				case 40:
				case 83:
					{
						p = new Point(Body.Last().X, Body.Last().Y + 1);
					}
					break;
			}

			if (p.X == 1 || p.X == Board.Size -1 || p.Y == 0 || p.Y == 14 || CheckSelf(p))
			{
				Console.Clear();
				Console.WriteLine("You Lose");
				Console.Read();
            }

			Body.Add(p);
			if (!Board.checkFruit(p))
			{
				Console.SetCursorPosition(Body[0].X, Body[0].Y);
				Console.Write(" ");
				Body.RemoveAt(0);
			}

			//Body.Add(new Point(Body.Last().X + 1, Body.Last().Y));

			Console.ForegroundColor = ConsoleColor.Green;
			for (int i = 0; i < Body.Count; i++)
			{
				Point item = Body[i];
				Console.SetCursorPosition(item.X, item.Y);
				Console.Write("*");
			}
		}
		
		public bool CheckSelf(Point p)
        {
			return Body.Any(x => x.X == p.X && x.Y == p.Y);
        }
	}
}
