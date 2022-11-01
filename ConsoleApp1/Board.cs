using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Board
    {
        private int size;

        public Board(int size)
        {
            this.size = size;
            CreateBoard();
        }

        /// <summary>
        /// Create the borders of the game depending on the indicated size
        /// </summary>
        /// <param name="size"></param>
        private void CreateBoard()
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

    }
}
