using System.Drawing;
using System.Reflection.Emit;

namespace ConsoleApp1
{
    internal class Fruit
    {      
        private Point fruit = new Point();

        public Point FruitPoints => fruit;

        /// <summary>
        /// Generate a fruit within the indicated borders
        /// </summary>
        /// <param name="boardSize"></param>
        public void GenerateFruit(int boardSize)
        {
            Random fruitposition = new Random();
          
            fruit = new Point(fruitposition.Next(1, boardSize - 1), fruitposition.Next(1, boardSize - 1));
          
            Console.SetCursorPosition(fruit.X, fruit.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
            Console.ResetColor();
        }
    }
}