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
    internal class Dot
    {
        private Point fruit;

        private List<Point> body = new List<Point>();

        int size;
        public Dot(int size)
        {
            body = new List<Point>
            {
                new Point(1,1),
                new Point(2,1),
                new Point(3,1),
            };
            this.size = size;
        }

        public void GameStart()
        {
            AutoMove();
        }

        public void GameOver()
        {
            Console.WriteLine("The game is over");
        }


        public void Render()
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

        public bool IsBoard(Point point)
        {
            if (point.X >= size-1 || point.Y >= size-1 || point.X <1 || point.Y < 1)
            {
                return true;
            }
            return false;
        }

        public void NewPosition(Point head)
        {
            if (body[body.Count -1] == fruit)
            {
                body.Insert(0, fruit);
                GenerateFruit();
            }

            if (IsSnake(head) || IsBoard(head))
            {

              
            }

            Point tail = body[0];

            for (int i = 0; i < body.Count - 1; i++)
            {
                body[i] = body[i+1]; 
            }

            body[body.Count-1] = head;

            Console.SetCursorPosition(tail.X, tail.Y);
            Console.Write(" ");

           
            foreach (var item in body)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("*");
            }  
        }


        public bool IsSnake(Point point)
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



        public void GenerateFruit()
        {
            Random fruitposition = new Random();

            while (true)
            {    
                fruit = new Point(fruitposition.Next(1, size - 1), fruitposition.Next(1, size - 1));
                if (!IsSnake(fruit)) break;
            }                     
            Console.SetCursorPosition(fruit.X, fruit.Y);
            Console.Write("@");
        }


        public void AutoMove()
        {
            Render();
            GenerateFruit();
            var direction = Direction.right;

            bool gameOver = false;
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
       public enum Direction
        {
            up,
            down,
            left,
            right
        }

        public void Moving(Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    AutoMoveUp();
                    break;
                case Direction.down:
                    AutoMoveDown();
                    break;
                case Direction.left:
                    AutoMoveLeft();
                    break;
                case Direction.right:
                    AutoMoveRight();
                    break;               
            }
        }


        public void AutoMoveUp()
        {          
            NewPosition(new Point(body[body.Count - 1].X, body[body.Count - 1].Y - 1));
            Thread.Sleep(200);
        }  
        
        public void AutoMoveDown()
        { 
             NewPosition(new Point(body[body.Count - 1].X, body[body.Count - 1].Y + 1));
             Thread.Sleep(200);          
        }  
  
        public void AutoMoveRight()
        {
            NewPosition(new Point(body[body.Count-1].X + 1, body[body.Count - 1].Y));
            Thread.Sleep(200);
        }   
        
        public void AutoMoveLeft()
        {
            NewPosition(new Point(body[body.Count - 1].X - 1, body[body.Count - 1].Y));
            Thread.Sleep(200);
        }


    }
}
