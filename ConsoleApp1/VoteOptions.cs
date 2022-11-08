using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem
{
    internal class VoteOptions
    {
        public static void EditOrDelete()
        {
            while (true)
            {
                if (VoteLogic.Votes == null)
                {
                    Console.WriteLine("Currently there are no active votes");
                    return;
                }

                Console.WriteLine("Select an action:");

                Console.WriteLine("1. Delete a Vote");

                Console.WriteLine("2. Edit a Vote.");

                Console.WriteLine("3. Reset a Vote.");

                Console.WriteLine("0. Exit.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        {
                            DeleteVote();
                            return;
                        }
                    case ConsoleKey.D2:
                        {
                            EditVote();
                            return;
                        }
                    case ConsoleKey.D3:
                        {
                            ResetVote();
                            return;
                        }
                    case ConsoleKey.D0:
                    default:
                        return;
                }
            }
        }

        private static void ResetVote()
        {
            Console.Clear();

            Console.WriteLine("Select the vote you want to Reset.");

            VoteLogic.DipayVotes();

            int numberOfItem;

            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < VoteLogic.Votes.Count && numberOfItem >= 0)
            {
                VoteLogic.Votes[numberOfItem - 1].ResetVote();

                Console.WriteLine("The Vote is Reseted.");
            }
            else
                Console.WriteLine("There are no polls for the entered index.");
        }

        private static void DeleteVote()
        {
            Console.Clear();

            Console.WriteLine("Select the vote you want to delete.");

            VoteLogic.DipayVotes();

            int numberOfItem;

            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < VoteLogic.Votes.Count && numberOfItem >= 0)
            {
                VoteLogic.Votes.RemoveAt(numberOfItem - 1);
                Console.WriteLine("The Vote is deleted.");
            }
            else
                Console.WriteLine("There are no polls for the entered index.");
            Console.ReadLine();
        }

        public static void EditVote()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Select an action:");

                Console.WriteLine("1. Change the name of the Vote.");

                Console.WriteLine("2. Change the answer options.");

                Console.WriteLine("0. Exit");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        {

                            ChangeTheName();
                            return;
                        }
                    case ConsoleKey.D2:
                        {
                            ChangeTheAnswer();
                            return;
                        }
                    case ConsoleKey.D0:
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void ChangeTheName()
        {
            Console.Clear();

            Console.WriteLine("Select the vote you want to edit.");

            VoteLogic.DipayVotes();

            int numberOfItem;

            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < VoteLogic.Votes.Count && numberOfItem >= 0)
            {
                Console.Clear();

                Console.WriteLine("Enter new Question:\t");
                VoteLogic.Votes[numberOfItem - 1].ReName(Console.ReadLine() ?? throw new FormatException());
            }
            else
                Console.WriteLine("There are no polls for the entered index.");
        }

        private static void ChangeTheAnswer()
        {
            Console.Clear();

            Console.WriteLine("Select the question you want to edit:");

            VoteLogic.DipayVotes();

            int numberOfItem;

            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < VoteLogic.Votes.Count && numberOfItem >= 0)
            {
                Console.Clear();

                Console.WriteLine("Select the answer you want to edit:");

                VoteLogic.Votes[numberOfItem - 1].DisplayAnsver();

                int numberOfAnswer;

                if (int.TryParse(Console.ReadLine(), out numberOfAnswer) && numberOfAnswer <= VoteLogic.Votes[numberOfItem - 1].AnswerOptions.Count && numberOfAnswer > 0)
                {
                    Console.Clear();

                    Console.Write("Enter new Answer:\t");

                    VoteLogic.Votes[numberOfItem - 1].AnswerOptions[numberOfAnswer - 1].ReName(Console.ReadLine() ?? throw new FormatException());
                }
                else
                    Console.WriteLine("There are no polls for the entered index.");

            }
            else
                Console.WriteLine("There are no polls for the entered index.");
        }
    }
}
