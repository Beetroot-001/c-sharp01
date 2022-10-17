using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class VoteCenter
    {
        private List<Vote> votes = new List<Vote>();
        string voteDataBasePath = Path.Combine(Directory.GetCurrentDirectory(), "VoteDataBase.csv");
        string voteResultsPath = Path.Combine(Directory.GetCurrentDirectory(), "VoteResults.csv");

        /// <summary>
        /// Create a new vote 
        /// </summary>
        public void CreateNewVote()
        {
            Console.WriteLine("Enter the name of your vote");
            string voteName = Console.ReadLine();          
            string record =  voteName;

            Console.WriteLine("Enter the number of answers your vote should contain");

            int.TryParse(Console.ReadLine(), out int answersNumber);

            if (answersNumber == 0)
            {
                Console.WriteLine("The number of answers should be digits and bigger than 0");
                Console.ReadKey();
                return;
            }

            Dictionary<int, string> answers = new Dictionary<int, string>();
            
            for (int i = 0; i < answersNumber; i++)
            {
                Console.WriteLine($"Enter your answer for option # {i+1}");
                string answer = Console.ReadLine();

                answers.Add(i + 1, answer);
                record += "/" + answer;
            }
            
            Console.WriteLine($"The vote <{voteName}> is succesfully added to the Vote Center");
            
            File.AppendAllText(voteDataBasePath, record + Environment.NewLine);
        }

        /// <summary>
        /// Write all existed votes from the file to dictionary
        /// </summary>
        public void ReadFile()
        {      
            string[] votes = File.ReadAllLines(voteDataBasePath);

            foreach (var item in votes)
            {
                string[] result = item.Split('/');
                
                string voteName = result[0];

                Dictionary<int, string> answers = new Dictionary<int, string>();

                for (int i = 1; i < result.Length; i++)
                {
                    string answer = result[i];

                    answers.Add(i, answer);
                }               
                this.votes.Add(new Vote(voteName, answers));
            }
        }
 
        /// <summary>
        /// Show the the names of all votes that were created
        /// </summary>
        public void ShowAllVotes()
        {
            votes.Clear();
            ReadFile();
            for (int i = 0; i < votes.Count; i++)
            {
                Console.WriteLine($"Vote #{i + 1}----> {votes[i].VoteName}");
            }
        }

        /// <summary>
        /// Select one of the existed votes and vote
        /// </summary>
        public void StartVoting()
        {
            ShowAllVotes();

            int voteChoice = 0; 
            while (voteChoice == 0 || voteChoice > votes.Count)
            {
                Console.WriteLine("Choose the vote you want to participate? 0 - to leave");

                if (int.TryParse(Console.ReadLine(), out voteChoice))
                {
                    if (voteChoice == 0)
                    {
                        return;
                    }
                    else if (voteChoice > votes.Count)
                    {
                        Console.WriteLine("Such vote doesn't exist in the list. Pls, choose the existed or create a new one.");
                    }
                }
                else
                {
                    Console.WriteLine("You should enter numbers to indicate what vote you want tot participate to.");
                }
            }
            votes[voteChoice-1].Voting(voteResultsPath);
            Console.ReadKey();
        }

        /// <summary>
        /// Show the results of all votes
        /// </summary>       
        public void ShowVoteResults()
        {
            string[] voteRecords = File.ReadAllLines(voteResultsPath);

            for (int i = 0; i < voteRecords.Length; i++)
            {
                string[] voteRecord = voteRecords[i].Split('/');

                string data = voteRecord[0];

                string voteName = voteRecord[1];

                Console.WriteLine("*************************");
                Console.WriteLine($"Date: {data}");
                Console.WriteLine($"Vote name: {voteName}");

                for (int k = 2; k < voteRecord.Length-1; k++)
                {
                    Console.WriteLine($"{voteRecord[k]}: {voteRecord[++k]}");
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Dispaly the vote center menu
        /// </summary>
        public void VoteMenu()
        {
            Console.WriteLine("1.Create new vote");
            Console.WriteLine("2.Participate in voting");
            Console.WriteLine("3.Show the results of all votes");
            Console.WriteLine("0.To exit");
        }

        /// <summary>
        /// Display vote center interface to create new votes, vote, and see results
        /// </summary>
        public void VoteInterface()
        {
            if (!File.Exists(voteDataBasePath)) File.Create(voteDataBasePath);
            if (!File.Exists(voteResultsPath)) File.Create(voteResultsPath);
          
            int option = 1;
            while (option!= 0)
            {
                Console.Clear();
                VoteMenu();
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        CreateNewVote();
                        break;
                    case 2:
                        Console.Clear();
                        StartVoting();
                        break;
                    case 3:
                        Console.Clear();
                        ShowVoteResults();
                        break;
                    case 0:
                        option = 0;
                        break;
                }
            }
        }
    }
}
