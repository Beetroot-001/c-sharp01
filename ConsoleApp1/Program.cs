using System.Threading;
using System.Timers;

namespace ConsoleApp1
{
	internal class Program
	{
        public static void Main()
        {
            Board board = new Board(20, 20);
            //board.RenderAll();
            board.StartGame();
        }

        //public void Move(object? sender, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("*");
        //}
    }
}