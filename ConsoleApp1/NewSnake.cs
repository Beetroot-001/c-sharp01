using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    internal class NewSnake
    {
        private int boardSize;       

        private List<Point> body = new List<Point>();     
        Direction defaultDirection = Direction.right;
        private System.Timers.Timer timer;

        Fruit fruit = new Fruit();
       
        public event Action GameEndEvent;
        public event Action LevelUpEvent;

        public NewSnake(int boardSize, int speed)
        {
            body = new List<Point>
            {
                new Point(1,1),
                new Point(2,1),
                new Point(3,1),
            };

            timer = new System.Timers.Timer(speed);
            this.boardSize = boardSize;
            fruit.GenerateFruit(boardSize);

            GameEndEvent += StopMotion;            
        }
        /// <summary>
        /// Start moving of the snake
        /// </summary>
        public void StartMotion()
        {
            timer.Start();
            timer.Elapsed += AutoMove;
            Thread.Sleep(Timeout.Infinite);
        }
        /// <summary>
        /// Stop moving of the snake
        /// </summary>
        private void StopMotion()
        {
            timer.Stop();
        }
    
        public void AutoMove(object? state, ElapsedEventArgs elapsedEventArgs)
        {
            if (Console.KeyAvailable)
            {
                var k = Console.ReadKey(true);
                ReadKey(k);
            }           
            Moving(defaultDirection);
        }

        /// <summary>
        /// Set the direction of the sanke 
        /// </summary>
        public void ReadKey(ConsoleKeyInfo k)
        {
            switch (k.Key)
            {
                case ConsoleKey.W:
                    if (defaultDirection == Direction.down) break;
                    defaultDirection = Direction.up;
                    break;

                case ConsoleKey.S:
                    if (defaultDirection == Direction.up) break;
                    defaultDirection = Direction.down;
                    break;

                case ConsoleKey.A:
                    if (defaultDirection == Direction.right) break;
                    defaultDirection = Direction.left;
                    break;

                case ConsoleKey.D:
                    if (defaultDirection == Direction.left) break;
                    defaultDirection = Direction.right;
                    break;
            }
        }

        /// <summary>
        /// Move snake to a new position 
        /// </summary>
        /// <param name="head"></param>
        private void NewPosition(Point head)
        {
            if (body[body.Count - 1] == fruit.FruitPoints)
            {
                body.Insert(0, fruit.FruitPoints);

                LevelUpEvent.Invoke();

                while (IsSnake(fruit.FruitPoints))
                {
                    fruit.GenerateFruit(boardSize);
                }
            }

            if (IsSnake(head) || IsBoard(head)) GameEndEvent.Invoke();

            Point tail = body[0];

            for (int i = 0; i < body.Count - 1; i++)
            {
                body[i] = body[i + 1];
            }

            body[body.Count - 1] = head;

            Console.SetCursorPosition(tail.X, tail.Y);
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in body)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("*");
            }
            Console.SetCursorPosition(body[body.Count - 1].X, body[body.Count - 1].Y);
            Console.Write("@");
            Console.ResetColor();
        }

        /// <summary>
        /// Direction of moving
        /// </summary>
        /// <param name="direction"></param>
        private void Moving(Direction direction)
        {
            Point movingDirection = default;
            switch (direction)
            {
                case Direction.up:
                    movingDirection = new Point(body[body.Count - 1].X, body[body.Count - 1].Y - 1);
                    break;
                case Direction.down:
                    movingDirection = new Point(body[body.Count - 1].X, body[body.Count - 1].Y + 1);
                    break;
                case Direction.left:
                    movingDirection = new Point(body[body.Count - 1].X - 1, body[body.Count - 1].Y);
                    break;
                case Direction.right:
                    movingDirection = new Point(body[body.Count - 1].X + 1, body[body.Count - 1].Y);
                    break;
            }
            NewPosition(movingDirection);
        }

        private enum Direction
        {
            up,
            down,
            left,
            right
        }

        /// <summary>
        /// Check if the snake meets the borders of the game
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Return true if meets, otherwise false </returns>
        private bool IsBoard(Point point)
        {
            if (point.X >= boardSize -1 || point.Y >= boardSize -1 || point.X < 1 || point.Y < 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the point is a part of snake 
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Return true if it is, otherwise false </returns</returns>
        private bool IsSnake(Point point)
        {
            foreach (var item in body)
            {
                if (item == point)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
