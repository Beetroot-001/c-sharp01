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
        private readonly int _sizeX;
        private readonly int _sizeY;

        public List<Dot> Walls { get; set; } // ??????

        public Board(int sizeX, int sizeY, Snake snake, Fruit fruit)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;

            DrawHorizontalWall();
            DrawVerticalWall();
            snake.DisplaySnake();

            snake.EatingFruit += fruit.NewFruit;
        }

        
        private void DrawHorizontalWall()
        {
            for (int i = 0; i <= _sizeX; i++)
            {
                Dot dotWalltop = new Dot(i,0,'#');
                Dot dotWalldown = new Dot(i, _sizeY, '#');

                dotWalltop.PrintDot();
                dotWalldown.PrintDot();
            }
        }

        private void DrawVerticalWall()
        {
            for (int i = 0; i <= _sizeY; i++)
            {
                Dot dotWalLeft = new Dot(0, i, '#');
                Dot dotWalRaight = new Dot(_sizeX, i, '#');

                dotWalLeft.PrintDot();
                dotWalRaight.PrintDot();
            }
        }

        public void DisplayScore()
        {
            Console.SetCursorPosition(_sizeX + 10, 1);
            Console.WriteLine($"Count of eat\t{Snake.CountOfEatten}");
        }
    }
}
