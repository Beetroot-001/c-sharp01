using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class Menu
    {
        public Board Board { get; private set; }
        static string[] menuStr = new string[3];    
        
        private Menu()
        {
            Board.DrawBoard();
            string newGame = "1. New Game";
            string leaderBoard = "2. LeaderBoard";
            menuStr[0] = newGame;
            menuStr[1] = leaderBoard;            
        }

        public static void DrawMenu()
        {
            Menu menu = new Menu();
            int x = Board.Size / 2;
            int y = Board.Size / 2;
            for (int i = 0; i < menuStr.Length; i++)
            {
                Console.SetCursorPosition(x - (menuStr[0].Length / 2), y - (menuStr.Length / 2) + i);                
                Console.WriteLine(menuStr[i]);
            }
            Select();

        }

        public static void Select()
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1 )
            {
                Game newGame = new();
                //Task.Delay(1500).Wait();
                Game.Start();                
            }
            else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
            {
                LeaderBoard.Show();
            }
        }

    }
}
