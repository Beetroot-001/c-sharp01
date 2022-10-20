using System.Drawing;
using System.Windows.Input;

namespace ConsoleApp1
{
	internal class Program
	{
        static  void Main(string[] args)
		{
            Snake game = new Snake(20);
            game.GameStart();

        } 
    }
}