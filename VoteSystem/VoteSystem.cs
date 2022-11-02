
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem
{
    public static class VooteSystem
    {
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
                            Console.Clear();

                            Console.WriteLine("Select the vote you want to edit.");

                            DipayVotes();

                            int numberOfItem;

                            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < Votes.Count && numberOfItem >= 0)
                            {
                                Console.Clear();

                                Console.WriteLine("Enter new Question:\t");
                                Votes[numberOfItem - 1].ReName(Console.ReadLine() ?? throw new FormatException());
                            }
                            else
                                Console.WriteLine("There are no polls for the entered index.");

                            return;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Clear();

                            Console.WriteLine("Select the question you want to edit:");

                            DipayVotes();

                            int numberOfItem;

                            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < Votes.Count && numberOfItem >= 0)
                            {
                                Console.Clear();

                                Console.WriteLine("Select the answer you want to edit:");

                                Votes[numberOfItem - 1].DisplayAnsver();

                                int numberOfAnswer;

                                if (int.TryParse(Console.ReadLine(), out numberOfAnswer) && numberOfAnswer <= Votes[numberOfItem - 1].AnswerOptions.Count && numberOfAnswer > 0)
                                {
                                    Console.Clear();

                                    Console.Write("Enter new Answer:\t");

                                    Votes[numberOfItem - 1].AnswerOptions[numberOfAnswer - 1].ReName(Console.ReadLine() ?? throw new FormatException());
                                }
                                else
                                    Console.WriteLine("There are no polls for the entered index.");

                            }
                            else
                                Console.WriteLine("There are no polls for the entered index.");
                            return;
                        }
                    case ConsoleKey.D0:
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void CreateVote()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the vote.");
            var newVote = new Vote(Console.ReadLine() ?? throw new FormatException());

            Console.WriteLine("Enter an answer option.");
            Answer answer = new Answer(Console.ReadLine() ?? throw new FormatException());
            newVote.AddAnswer(answer);

            Console.Clear();

            AddAnswer(newVote);

            if (Votes == null)
            {
                Votes = new List<Vote>();
                Votes.Add(newVote);
            }
            else
            {
                Votes.Add(newVote);
            }

        }

        public static void DipayVotes()
        {
            int i = 1;

            foreach (var item in Votes)
            {
                Console.WriteLine($"{i} {item.Name}");

                i++;
            }
        }

        public static void AddAnswer(Vote newVote)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Progress saved!\nSelect an action:");

                Console.WriteLine("1. Add an answer option.");

                Console.WriteLine("0. Exit.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();

                            Console.WriteLine("Enter an answer option.");
                            var answer = new Answer(Console.ReadLine() ?? throw new FormatException());
                            Console.WriteLine("Answer are add");

                            newVote.AddAnswer(answer);
                            continue;
                        }
                    case ConsoleKey.D0:
                    default:
                        return;
                }
            }
        }

        public static void Vote()
        {
            Console.Clear();

            if (Votes != null)
            {
                Console.WriteLine("Choose the vote you want to participate in.");

                DipayVotes();

                int numberOfItem;

                if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < Votes.Count && numberOfItem >= 0)
                {
                    Console.Clear();

                    Console.WriteLine("Select the answer you want to vote for.");

                    Votes[numberOfItem - 1].DisplayVote();

                    int numberOfAnsver;

                    if (int.TryParse(Console.ReadLine(), out numberOfAnsver) && numberOfAnsver <= Votes[numberOfItem - 1].AnswerOptions.Count && numberOfAnsver >= 0)
                    {
                        Votes[numberOfItem - 1].AnswerOptions[numberOfAnsver - 1].IncreaseCount();

                        Console.WriteLine("Your vote has been accepted");

                        Console.WriteLine(Votes[numberOfItem - 1].AnswerOptions[numberOfAnsver - 1].Data);
                    }
                    else
                        Console.WriteLine("There are no polls for the entered index.");
                }
                else
                    Console.WriteLine("There are no polls for the entered index.");
            }
            else
                Console.WriteLine("Currently there are no active votes");
            Console.ReadLine();
            return;
        }

        public static void ViewVotingResults()
        {
            Console.Clear();

            if (Votes != null)
            {
                Console.WriteLine("Choose the vote you want to participate in.");

                DipayVotes();

                int numberOfItem;

                if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < Votes.Count && numberOfItem >= 0)
                {
                    Votes[numberOfItem - 1].DisplayVoteResults();
                }
                else
                    Console.WriteLine("There are no polls for the entered index.");
            }
            else
                Console.WriteLine("Currently there are no active votes");

            Console.ReadLine();
            return;
        }

        public static void EditOrDelete()
        {
            while (true)
            {
                if (Votes == null)
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

            DipayVotes();

            int numberOfItem;

            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < Votes.Count && numberOfItem >= 0)
            {
                Votes[numberOfItem - 1].ResetVote();

                Console.WriteLine("The Vote is Reseted.");
            }
            else
                Console.WriteLine("There are no polls for the entered index.");
        }

        private static void DeleteVote()
        {
            Console.Clear();

            Console.WriteLine("Select the vote you want to delete.");

            DipayVotes();

            int numberOfItem;

            if (int.TryParse(Console.ReadLine(), out numberOfItem) && numberOfItem - 1 < Votes.Count && numberOfItem >= 0)
            {
                Votes.RemoveAt(numberOfItem - 1);
                Console.WriteLine("The Vote is deleted.");
            }
            else
                Console.WriteLine("There are no polls for the entered index.");
            Console.ReadLine();
        }

        public static void Display()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose your option.");

                Console.WriteLine("1. Create Vote.");

                Console.WriteLine("2. Edit or Delete a Vote.");

                Console.WriteLine("3. Vote.");

                Console.WriteLine("4. View voting results.");

                Console.WriteLine("0. Exit.");


                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        CreateVote();
                        continue;
                    case ConsoleKey.D2:
                        Console.Clear();
                        EditOrDelete();
                        continue;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Vote();
                        continue;
                    case ConsoleKey.D4:
                        Console.Clear();
                        ViewVotingResults();
                        continue;
                    case ConsoleKey.D0:
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static List<Vote> Votes { get; set; } = null;

    }
}
