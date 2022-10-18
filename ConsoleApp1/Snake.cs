using System.Drawing;
using System.Timers;

namespace ConsoleApp1
{
    internal class Snake
    {

        private List<Point> body = new List<Point>();

        public Snake()
        {
            body = new List<Point>
            {
                new Point(1,1),
                new Point(2,1),
                new Point(3,1),
            };
        }

        public List<Point> Body => body;
        public int SnakeSize => body.Count; 



        public void Move(object? sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(Body[0].X, Body[0].Y);
            Console.Write(" ");

            Body.RemoveAt(0);
            Body.Add(new Point(Body.Last().X + 1, Body.Last().Y));

            Console.ForegroundColor = ConsoleColor.Green;
           
            for (int i = 0; i < Body.Count; i++)
            {
                Point item = Body[i];
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("*");
            }






        }

    }
}