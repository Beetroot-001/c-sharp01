using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;

namespace ConsoleApp1
{
    public class ConsoleInterface
    {
        private List<Vote> _votes;

        public ConsoleInterface()
        {
            _votes = new List<Vote>();
        }

        private void ShowList<T>(List<T> list, string offset = "")
        {
            if (list is null || list.Count == 0)
            {
                Console.WriteLine("no items");
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{offset}{i + 1}. {(list[i] is not null ? list[i].ToString() : "null")}");
            }
        }

        private int Input(Predicate<int> predicate)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) && predicate(input))
            {
                Console.WriteLine("incorrect input");
            }
            return input - 1;
        }

        public void StartInterface()
        {
            bool runFlag = true;
            while (runFlag)
            {
                Console.WriteLine("Voter program");
                Console.WriteLine("1. Show votes");
                Console.WriteLine("2. Vote");
                Console.WriteLine("3. Create vote");
                Console.WriteLine("0. Exit");

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        ShowVotes();
                        break;
                    case ConsoleKey.D2:
                        Vote();
                        break;
                    case ConsoleKey.D3:
                        break;
                    default:
                        runFlag = false;
                        return;
                }
            }
        }

        private int ShowVotes()
        {
            ShowList(_votes);

            if (_votes is not null || _votes.Count > 0)
            {
                Console.WriteLine("Enter vote number");
                int input = Input(input => input > 0 && input <= _votes.Count);
                Console.WriteLine(_votes[input].ToString());
                ShowList(_votes[input].Options, "\t");
                return input;
            }
            return -1;
        }

        private void Vote()
        {
            int voteNum = ShowVotes();

            if (voteNum != -1)
            {
                Console.WriteLine();
                Console.WriteLine("Enter option number");
                int input = Input(input => input > 0 && input <= _votes[voteNum].Options.Count);
                _votes[voteNum].VoteMethod(input);
            }
        }

        private void CreateVote()
        {
            Console.WriteLine("Enter vote title");
            Vote vote = new Vote(Console.ReadLine() ?? "null");

            bool runFlag = true;
            while (runFlag)
            {
                Console.WriteLine("Vote options");
                Console.WriteLine("1. Add new option");
                Console.WriteLine("0. Exit");

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Enter option name");
                        VoteOption option = new VoteOption(Console.ReadLine() ?? "null");
                        vote.Options.Add(option);
                        break;
                    default:
                        runFlag = false;
                        return;
                }
            }

            _votes.Add(vote);
            Console.WriteLine("Vote successfully added");
        }
    }
}