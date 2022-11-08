using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Vote
    {
        public string Name { get; private set; }
        public List<Answer> AnswerOptions { get; private set; } 

        public Vote(string name)
        {
            Name = name;
            AnswerOptions = new List<Answer>();
        }



        /// <summary>
        /// Displays the question and possible answer options
        /// </summary>
        public void DisplayVote()
        {
            int i = 1;
            Console.WriteLine($"{this.Name}");
            foreach (var item in AnswerOptions)
            {
                Console.WriteLine($"{i} {item.Data}");
                i++;
            }
        }

        /// <summary>
        /// Displays questions and answer options with the number of votes cast for them
        /// </summary>
        public void DisplayVoteResults()
        {
            Console.WriteLine($"{this.Name}");
            foreach (var item in AnswerOptions)
            {
                Console.WriteLine($"{item.Data}:\t Results: {item.Count}");
            }
        }

        public void DisplayAnsver()
        {
            int i = 1;
            foreach (var item in AnswerOptions)
            {
                Console.WriteLine($"{i} {item.Data}");
                i++;
            }
        }

        /// <summary>
        /// Drops loyal votes
        /// </summary>
        public void ResetVote()
        {
            foreach (var item in this.AnswerOptions)
            {
                item.ResetCount();
            }
        }

        /// <summary>
        /// Adds one to the answer vote count
        /// </summary>
        /// <param name="answerNumber"></param>
        public void AddVoice(int answerNumber) => AnswerOptions[answerNumber].IncreaseCount();

        /// <summary>
        /// Changes the name of the vote
        /// </summary>
        /// <param name="voise"></param>
        public void ReName(string newVoteName) => this.Name = newVoteName;

        /// <summary>
        /// Changes the Answer text
        /// </summary>
        /// <param name="NameofAnswer"></param>
        /// <param name="answerNumber"></param>
        public void EditAnswer(string NameofAnswer, int answerNumber) => this.AnswerOptions[answerNumber].ReName(NameofAnswer);

        /// <summary>
        /// Adds a Answer
        /// </summary>
        /// <param name="newAnswer"></param>
        public void AddAnswer(Answer newAnswer) => this.AnswerOptions.Add(newAnswer);

        /// <summary>
        /// Deletes Answer
        /// </summary>
        /// <param name="numberOfQuestion"></param>
        public void DellAnswer(int answerNumber) => this.AnswerOptions.RemoveAt(answerNumber);
    }
}
