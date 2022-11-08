using VoteSystem;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VoteLogic.Display();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}