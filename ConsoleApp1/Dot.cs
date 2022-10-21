using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal struct Dot
    {
        public Dot(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        /// <summary>
        /// Displays the dot on the screen
        /// </summary>
        /// <param name="consoleColor"></param>
        public void PrintDot(ConsoleColor consoleColor = ConsoleColor.Blue)
        {
            DisplayPoint(Symbol);
            Console.ForegroundColor = consoleColor;
        }

        public void DelDote()
        {
            DisplayPoint(' ');
        }

        private void DisplayPoint( char symbol)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(symbol);
        }

        /// <summary>
        /// Compares if two dots are equally positioned
        /// </summary>
        /// <param name="dot"></param>
        /// <returns></returns>
        public  bool Equals(Dot dot)
        {
            return X == dot.X && Y == dot.Y;
        }
    }
}
