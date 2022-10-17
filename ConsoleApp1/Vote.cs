using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    internal class Vote
    {
        private string name;
        private Dictionary<int, string> answers = new Dictionary<int, string>();
        private int[] voteResults;       

        public Vote(string name, Dictionary<int, string> answers)
        {
            this.name = name;
            this.answers = answers;
        }

        public string VoteName => name;

        /// <summary>
        /// Display the vote info
        /// </summary>
        public void ShowVote()
        {
            Console.WriteLine(name);
            foreach (var item in answers)
            {
                Console.WriteLine($"{item.Key}. {item.Value}");
            }
        }

        /// <summary>
        /// Do voting
        /// </summary>
        /// <param name="path"></param>
        public void Voting(string path)
        {
            ShowVote();

            Console.WriteLine("Select the answer to vote");
            int answer = 0;

            while (answer == 0 || answer > answers.Count)
            {
                if (int.TryParse(Console.ReadLine(), out answer) == true && answer <= answers.Count) break;
              
                Console.WriteLine("Pls, select one of the provided options");
            }

            voteResults = new int[answers.Count];
            voteResults[answer - 1] += 1;
            GenerateRandomVoting();
            RecordVoteResult(path);

            Console.WriteLine("Please, wait for other voters");
            for (int i = 5; i >= 0; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{i}...");
            }
            Console.Clear();
            ShowVoteResult();
        }

        /// <summary>
        /// Record the result of voting to a particular file
        /// </summary>
        /// <param name="path"></param>
        private void RecordVoteResult(string path)
        {
            string results = null;

            for (int i = 0; i < answers.Count; i++)
            {
                results += answers.ElementAt(i).Value + "/" + voteResults[i] + "/";
            }

            string record = string.Join("/", DateTime.Now.ToUniversalTime(), name, results);
            File.AppendAllText(path, record + Environment.NewLine);
        }

        /// <summary>
        /// Show the result of voting
        /// </summary>
        public void ShowVoteResult()
        {
            Console.WriteLine($"The result of voting <{name}>");

            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine($"{answers[i + 1]}: {voteResults[i]}");
            }
        }

        /// <summary>
        /// Generate number of people who participate in voting
        /// </summary>
        /// <param name="voters"></param>
        private void GenerateRandomVoting(int voters = 20)
        {
            Random rand = new Random();

            for (int i = 0; i < voters; i++)
            {
                voteResults[rand.Next(answers.Count)] += 1;
            }
        }
    }
}
