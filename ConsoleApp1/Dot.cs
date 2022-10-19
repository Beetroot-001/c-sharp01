using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    internal class Dot
    {

        private Point dot;

        private List<Point> body = new List<Point>();
        public Dot()
        {
            //dot.X = 0;
            //dot.Y = 0;
            //Console.SetCursorPosition(dot.X, dot.Y);           
            //Console.Write("*");

            body = new List<Point>
            {
                new Point(1,1),
                new Point(2,1),
                new Point(3,1),
            };

            

        }

        
        public List<Point> Body => body;
        public int SnakeSize => body.Count;


        public Point CurrentPosition => dot;



        public void NewPosition(Point point)
        {
        
            Point tail = body[0];

            for (int i = 0; i < body.Count - 1; i++)
            {
                body[i] = body[i+1]; 
            }

            body[body.Count-1] = point;

            Console.SetCursorPosition(tail.X, tail.Y);
            Console.Write(" ");

            foreach (var item in body)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("*");
            }

            
        }







        public void AutoMove2()
        {
            var direction = Direction.right;
 
            while (true)
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
            Thread.Sleep(500);
        }  
        
        public void AutoMoveDown()
        { 
             NewPosition(new Point(body[body.Count - 1].X, body[body.Count - 1].Y + 1));
             Thread.Sleep(500);          
        }  
  
        public void AutoMoveRight()
        {
            NewPosition(new Point(body[body.Count-1].X + 1, body[body.Count - 1].Y));
            Thread.Sleep(500);
        }   
        
        public void AutoMoveLeft()
        {
            NewPosition(new Point(body[body.Count - 1].X - 1, body[body.Count - 1].Y));
            Thread.Sleep(500);
        }


    }
}
