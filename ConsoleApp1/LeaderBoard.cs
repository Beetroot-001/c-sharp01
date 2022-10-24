using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LeaderBoard
    {        
        static List<Results> results;
        private LeaderBoard()
        {
            results = new List<Results>();
        }

        public static void Show()
        {
            Board.DrawBoard();
            int i = 1;
            var res = results.OrderByDescending(x => x.score);
            foreach (var result in res)
            {
                Console.SetCursorPosition(1, i);                
                Console.WriteLine(result.name + " " + result.score);
                i++;
            }
            Console.ReadLine();
            if (Console.KeyAvailable)
            {
                Menu.DrawMenu();
            }
        }

        public static void AddResult(int score)
        {
            if (results == null)
            {
                LeaderBoard leaderBoard = new();              
                
            }
            Results result = new Results();
            result.score = Snake.score;
            results.Add(result);             
            Menu.DrawMenu();
        }

        private class Results
        {
            public string name { get; internal set; }
            public int score { get; internal set; }
            public Results()
            {
                Console.SetCursorPosition(1, 1);
                Console.Write("Enter name: ");
                this.name = Console.ReadLine();                
            }           
        }

    }
}
