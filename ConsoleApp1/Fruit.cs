namespace ConsoleApp1
{
    public class Fruit
    {
        public Point point;

        public Fruit()
        {

        }

        public void CreateFruit()
        {
            bool ok = false;
            Random rand = new((int)DateTime.Now.Ticks);
            while (!ok)
            {
                ok = true;
                int x = rand.Next(1, Board.Size - 1);
                int y = rand.Next(1, Board.Size - 1);
                for (int i = 0; i < Snake.Body.Count; i++)
                {
                    if (x == Snake.Body[i].x || y == Snake.Body[i].y)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    point = new(x, y);
                    Console.SetCursorPosition(point.x, point.y);
                    Console.Write("o");
                }
            }
        }

    }
}