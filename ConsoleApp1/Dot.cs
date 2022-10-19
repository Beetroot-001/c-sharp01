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
        public Dot()
        {
            dot.X = 0;
            dot.Y = 0;
            Console.SetCursorPosition(dot.X, dot.Y);
            
            Console.Write("*");
        }

        public Point CurrentPosition => dot;

        public void NewPosition(Point point)
        {
            Console.SetCursorPosition(dot.X, dot.Y);
            Console.Write(" ");
            Console.Write(" ");

            dot = point;

            Console.SetCursorPosition(dot.X, dot.Y);
            Console.Write("*");           
        }



        //public void AutoMove(object? sender, ElapsedEventArgs e)
        //{
        //    NewPosition(new Point(dot.X + 1, dot.Y));
        //}     
        
        public void AutoMove2()
        {
            var direction = Direction.right;
 
            while (true)
            {
                Moving(direction);

                if (Console.KeyAvailable)
                {
                    var k = Console.ReadKey();

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
            NewPosition(new Point(dot.X, dot.Y - 1));
            Thread.Sleep(500);
        }  
        
        public void AutoMoveDown()
        {
             NewPosition(new Point(dot.X, dot.Y + 1));
             Thread.Sleep(500);          
        }  
  
        public void AutoMoveRight()
        {
            NewPosition(new Point(dot.X + 1, dot.Y));
            Thread.Sleep(500);
        }   
        
        public void AutoMoveLeft()
        {
            NewPosition(new Point(dot.X - 1, dot.Y));
            Thread.Sleep(500);
        }



        //public void Move(object key)
        //{

        //    var key1 = (ConsoleKeyInfo)key;
        //    switch (key1.Key)
        //    {
        //        case ConsoleKey.W:
                            
        //            NewPosition(new Point(dot.X, dot.Y-1));
        //            break;
        //        case ConsoleKey.S:

        //            NewPosition(new Point(dot.X, dot.Y + 1));
        //            break;

        //        case ConsoleKey.A:
        //            NewPosition(new Point(dot.X -1, dot.Y));
                  
        //            break;
        //        case ConsoleKey.D:
                    
        //            NewPosition(new Point(dot.X + 1, dot.Y));
                
        //            break;

        //    }

        //}




    }
}
