using System.Drawing;
using System.Windows.Input;

namespace ConsoleApp1
{
	internal class Program
	{
        

        private static System.Timers.Timer timer;



        public delegate void Method ();

        public static void ShowTime()
        {
            int i = 0;
            
            while (true)
            {
                Thread.Sleep(500);
                Console.WriteLine(i++);


                if (Console.KeyAvailable)
                {
                    Console.WriteLine("Stop");
                    break;
                }

                } 
        }

        public static void ShowMessage()
        {
            Console.ReadLine();
        }



        public static event Method OnCount; 


        static  void Main(string[] args)
		{

            //OnCount += ShowMessage;




            Dot dot = new Dot(20);



            dot.GameStart();







        }

      
    }
}