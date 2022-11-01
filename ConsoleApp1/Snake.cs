using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    internal class Snake
    {
        private Point fruit;
        private bool gameOver = false;
        private List<Point> body = new List<Point>();
        private int size;
        private int score = 0;
        private int speed;
        private int speedCounter = -1;
        private int level;

        public Snake (int size)
        {
            body = new List<Point>
            {
                new Point(1,1),
                new Point(2,1),
                new Point(3,1),
            };
            this.size = size;

            speed = 300;
        }

        public void GameStart()
        {
            CreateBoard(size);
            ScoreTable();
            GenerateFruit();
            AutoMove();
        }

        private void GameOver()
        {
            gameOver = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(size/4, size/3);
            Console.WriteLine("Game Over");
            Console.SetCursorPosition((size / 4) -2, (size / 3)+1);
            Console.WriteLine($"Total Score: {score}");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Display the current score and snake's speed
        /// </summary>
        private void ScoreTable()
        {
            Console.SetCursorPosition(size+1, 0);
            Console.WriteLine($"Total score: {score}");
            Console.SetCursorPosition(size + 1, 1);
            Console.WriteLine($"Speed: {level}");
        }

        /// <summary>
        /// Create the borders of the game depending on the indicated size
        /// </summary>
        /// <param name="size"></param>
        private void CreateBoard(int size)
        {
            ///Board
            for (int i = 0; i < size; i++)
            {
                char a = '"';

                Console.ForegroundColor = ConsoleColor.Yellow;
                ///left colomn
                Console.SetCursorPosition(0, i);
                Console.Write(a);

                ///right colomn
                Console.SetCursorPosition(size - 1, i);
                Console.Write(a);

                ///top
                Console.SetCursorPosition(i, 0);
                Console.Write(a);

                ///bottom
                Console.SetCursorPosition(i, size - 1);
                Console.Write(a);

                Console.ResetColor();
            }
        }

        /// <summary>
        /// Check if the snake meets the borders of the game
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Return true if meets, otherwise false </returns>
        private bool IsBoard(Point point)
        {
            if (point.X >= size-1 || point.Y >= size-1 || point.X <1 || point.Y < 1)
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

        /// <summary>
        /// Create a fruit in a random position excluding game borders and snake's body
        /// </summary>
        private void GenerateFruit()
        {
            Random fruitposition = new Random();

            while (true)
            {    
                fruit = new Point(fruitposition.Next(1, size - 1), fruitposition.Next(1, size - 1));
                if (!IsSnake(fruit)) break;
            }                     
            Console.SetCursorPosition(fruit.X, fruit.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
            Console.ResetColor();

            speedCounter++;
            if (speedCounter == 5)
            {
                speed -= 50;
                speedCounter = 0;
                level++;
                Console.Beep(700,1200);
            }
        }

      /// <summary>
      /// Auto move + option to choose the direction
      /// </summary>
        private void AutoMove()
        {
            var direction = Direction.right;

            while (!gameOver)
            {
                Moving(direction);

                if (Console.KeyAvailable)
                {
                    var k = Console.ReadKey(true);

                    switch (k.Key)
                    {
                        case ConsoleKey.W:
                            if (direction == Direction.down) break;
                            direction = Direction.up;
                            break;

                        case ConsoleKey.S:
                            if (direction == Direction.up) break;
                            direction = Direction.down;
                            break;

                        case ConsoleKey.A:
                            if (direction == Direction.right) break;
                            direction = Direction.left;
                            break;

                        case ConsoleKey.D:
                            if (direction == Direction.left) break;
                            direction = Direction.right;
                            break;
                    }
                }
            }
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
            Thread.Sleep(speed);
        }

        /// <summary>
        /// Move snake to a new position 
        /// </summary>
        /// <param name="head"></param>
        private void NewPosition(Point head)
        {
            if (body[body.Count - 1] == fruit)
            {
                body.Insert(0, fruit);
                GenerateFruit();
                score++;
                ScoreTable();
            }

            if (IsSnake(head) || IsBoard(head)) GameOver();

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
        /// The direction of snake 
        /// </summary>
        private enum Direction
        {
            up,
            down,
            left,
            right
        }

    }
}
