using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class VoteCenter
    {
        private List<Vote> votes = new List<Vote>();


        public void CreateNewVote()
        {
            Console.WriteLine("Enter the name of your vote");
            string voteName = Console.ReadLine();

            Console.WriteLine("Enter the number of answers your vote should contains");
            int.TryParse(Console.ReadLine(), out int answersNumber);

            Dictionary<int, string> answers = new Dictionary<int, string>();
            
            for (int i = 0; i < answersNumber; i++)
            {
                Console.WriteLine($"Enter your answer for option # {i+1}");
                answers.Add(i + 1, Console.ReadLine());
            }
            votes.Add(new Vote(voteName, answers));
            Console.WriteLine($"The vote <{voteName}> is succesfully added to the Vote Center");
          
        }


        






    }
}
