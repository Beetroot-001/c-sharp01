using System.ComponentModel;
using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameManager manager = GameManager.Start();
            manager.Update();
            Thread.Sleep(Timeout.Infinite);
        }
    }

}