using System.Drawing;
using System.Timers;
using System.Windows.Input;

namespace ConsoleApp1
{
	internal class Program
	{
        static void Main(string[] args)
		{
            Game game = new Game(20);
            game.Start();

        }
    }
}