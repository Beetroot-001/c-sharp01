using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Fruit
    {
        Random random = new Random((int)DateTime.Now.Ticks);

        public Fruit(int x, int y, char symbol, ConsoleColor consoleColor = ConsoleColor.Green)
        {
            SizeX = x;
            SyzeY = y;
            Symbol = symbol;
            _fruitColor = consoleColor;
        }

        private ConsoleColor _fruitColor;
        public int SizeX { get; private set; }

        public int SyzeY { get; private set; }

        public char Symbol { get; private set; }

        public Dot Dot  { get; private set; }

        /// <summary>
        /// Creates a new fruit on the board
        /// </summary>
        public void NewFruit()
        {
            Dot = new Dot(random.Next(1, this.SizeX - 1), random.Next(1, this.SyzeY - 1), Symbol);

           Dot.PrintDot(_fruitColor);
        }

        /// <summary>
        /// Checks if the new fruit appered on the snakes body. yes = true; no = false
        /// </summary>
        /// <param name="snake"></param>
        /// <returns></returns>
        public bool IsSpawnInSnake(Snake snake)
        {
            foreach (var item in snake.SnakeBody)
            {
                if (item.Equals(this.Dot))
                {
                    return true;
                }
            }
            return false;
        }
       

    }
}
