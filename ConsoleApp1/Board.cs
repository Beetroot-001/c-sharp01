using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Board
    {

        private int size;
        private Snake snake;
        private Fruit fruit;

        private System.Timers.Timer timer;

        public Board(int size)
        {
            snake = new Snake();
            fruit = new Fruit();
            this.size = size;

            timer = new System.Timers.Timer(1000);

            timer.Elapsed += snake.Move;
        }


        public void Render()
        {
            timer.Start();

            ///Board
            for (int i = 0; i < size; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                ///left colomn
                Console.SetCursorPosition(0, i);
                Console.Write("*");

                ///right colomn
                Console.SetCursorPosition(size - 1, i);
                Console.Write("*");

                ///top
                Console.SetCursorPosition(i, 0);
                Console.Write("*");

                ///bottom
                Console.SetCursorPosition(i, size - 1);
                Console.Write("*");
            }

            //Console.ResetColor();


            // snake
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < snake.SnakeSize; i++)
            {
                Point item = snake.Body[i];
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write("*");
            }





        }







    }
}
