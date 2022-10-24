using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    public class Snake
    {
        public static int score { get; private set; } = 0;
        public char SnakeChar { get; set; }
        public static Point point { get; private set; }
        public static List<Point> Body { get; private set; }

        public Snake()
        {
            point = new Point(Board.Size / 2, Board.Size / 2);
            Body = new List<Point>
            {
                new Point(Board.Size / 2, Board.Size / 2),
                new Point((Board.Size / 2), Board.Size / 2),
                new Point((Board.Size / 2), Board.Size / 2),
            };
        }

        public void MoveSnake(object? sender, ElapsedEventArgs e)
        {
            Direction.GetDirection();
            int side = (int)Direction.eDirection;            
            switch (side)
            {
                case 0: Body.Add(new Point(Body.Last().x, Body.Last().y - 1)); SnakeChar = '^'; break;
                case 1: Body.Add(new Point(Body.Last().x, Body.Last().y + 1)); SnakeChar = 'V'; break;
                case 2: Body.Add(new Point(Body.Last().x - 1, Body.Last().y)); SnakeChar = '<'; break;
                case 3: Body.Add(new Point(Body.Last().x + 1, Body.Last().y)); SnakeChar = '>'; break;
            }

            Console.SetCursorPosition(Body[0].x, Body[0].y);
            Console.Write(" ");
            Body.RemoveAt(0);
            CheckBoard();            
            Render();
            CheckFruit();
            CheckIfCol();

        }

        public void EatFruit(Fruit fruit)
        {
            Direction.EDirection dir = Direction.eDirection;
            switch (dir)
            {
                case Direction.EDirection.North:
                    Body.Add(new Point(Body.Last().x, Body.Last().y - 1));
                    break;
                case Direction.EDirection.South:
                    Body.Add(new Point(Body.Last().x, Body.Last().y + 1));
                    break;
                case Direction.EDirection.West:
                    Body.Add(new Point(Body.Last().x - 1, Body.Last().y));
                    break;
                case Direction.EDirection.East:
                    Body.Add(new Point(Body.Last().x + 1, Body.Last().y));
                    break;
            }
            score++;
            fruit.CreateFruit();
        }

        public void CheckIfCol()
        {
            Task.Delay(1500).Wait();
            for (int i = 1; i < Body.Count; i++)
            {
                if (Body[i].x == Body[0].x && Body[i].y == Body[0].y)
                {
                    Game.Lose();
                    score = 0;
                }
            }
        }

        public void CheckBoard()
        {
            if (Body[Body.Count - 1].x == Board.Size || Body[Body.Count - 1].y == Board.Size || Body[Body.Count - 1].x == 0 || Body[Body.Count - 1].y == 0)
            {
                Game.Lose();
                score = 0;
            }
        }

        public void CheckFruit()
        {
            if (Board.fruit.point.x == Body.Last().x && Board.fruit.point.y == Body.Last().y)
            {
                EatFruit(Board.fruit);
            }
        }

        public void Render()
        {
            for (int i = 0; i < Body.Count; i++)
            {
                Point item = Body[i];
                Console.SetCursorPosition(item.x, item.y);
                if (item == Body[Body.Count - 1])
                {
                    Console.Write(SnakeChar);
                }
            }            
        }

    }

}
