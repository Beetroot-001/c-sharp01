using System.Threading;
using System.Timers;

namespace ConsoleApp1
{
	internal class Program
	{
        public static void Main()
        {
            Board.GetBoard(20, 20);
            Board.StartGame();
        }
    }
}