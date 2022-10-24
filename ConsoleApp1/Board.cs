using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    internal class Board
    {
        public static int Size { get; set; } = 50;
        Snake Snake { get; set; }
        internal static System.Timers.Timer timer;
        public static Fruit fruit { get; set; }

        public Board()
        {
            Snake = new Snake();
            Point point = new(1, 1);
            timer = new System.Timers.Timer(500);
            timer.Elapsed += Snake.MoveSnake;
            timer.Start();
            fruit = new();
            fruit.CreateFruit();
        }

        public static void DrawBoard()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("╔");
            Console.SetCursorPosition(0, Size);
            Console.WriteLine("╚");
            Console.SetCursorPosition(Size, 0);
            Console.WriteLine("╗");
            Console.SetCursorPosition(Size, Size);
            Console.WriteLine("╝");
            Console.SetCursorPosition(1, 0);
            string vertical = "║";
            string horizontal = "═";
            for (int i = 0; i < Size - 1; i++)
            {
                Console.SetCursorPosition(i + 1, 0);
                Console.Write(horizontal);
                Console.SetCursorPosition(i + 1, Size);
                Console.Write(horizontal);
                Console.SetCursorPosition(0, i + 1);
                Console.Write(vertical);
                Console.SetCursorPosition(Size, i + 1);
                Console.Write(vertical);
            }
        }
        public void Stop() => timer.Stop();

    }

    public class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Direction
    {
        public enum EDirection
        {
            North,
            South,
            West,
            East,
        }
        public static EDirection eDirection = EDirection.East;

        public static void GetDirection()
        {
            while (Console.KeyAvailable)
            {
                eDirection = EDirection.East;
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
                {
                    if (eDirection != EDirection.South)
                    {
                        eDirection = EDirection.North;
                    }
                }
                else if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow)
                {
                    if (eDirection != EDirection.East)
                    {
                        eDirection = EDirection.West;
                    }
                }
                else if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
                {
                    if (eDirection != EDirection.North)
                    {
                        eDirection = EDirection.South;
                    }
                }
                else if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
                {
                    if (eDirection != EDirection.West)
                    {
                        eDirection = EDirection.East;
                    }
                }
            }

        }  
        
    }

}
