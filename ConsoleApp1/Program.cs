using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.ShowMenu();
        }
        public class Menu
        {
            static List<Poll> Polls { get; set; } = new List<Poll>();
            static int iterator { get; set; } = 1;
            public static void ShowMenu()
            {
                Console.WriteLine("1. Create Poll\n2. Vote for the poll\n3. View results");
                Choose();
            }
            public static void Choose()
            {
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Poll poll = new();
                        Polls.Add(poll);
                        ShowMenu();
                        break;
                    case "2":
                        ShowList();
                        Console.WriteLine("Choose a poll: ");
                        int choice1 = Parser(Console.ReadLine());
                        Poll chosenPoll = Polls[choice1 - 1];
                        if (choice1 <= Polls.Count && chosenPoll.my == 0)
                        {
                            Console.WriteLine(Polls[choice1 - 1].PollQuestion + "\n1. Approve             2. Deny");
                            bool n = (Parser(Console.ReadLine()) == 1) ? true : false;
                            chosenPoll.Vote(n);
                            ShowMenu();
                        }
                        else
                        {
                            chosenPoll.ShowResults();
                            Console.WriteLine("Choose an option: ");
                            int choice3 = Parser(Console.ReadLine());
                            chosenPoll.Vote(chosenPoll.variants[choice3 - 1]);
                            chosenPoll.ShowResults();
                            ShowMenu();
                        }
                        break;
                    case "3":
                        ShowList();
                        Console.WriteLine("Choose a poll: ");
                        int choice2 = Parser(Console.ReadLine());
                        Polls[choice2 - 1].ShowResults();
                        ShowMenu();
                        break;
                    default:
                        break;
                }
            }
            public static int Parser(string str)
            {
                Int32.TryParse(str, out int i);
                return i;
            }
            public static void ShowList()
            {
                if (Polls[0] != null)
                {
                    foreach (var item in Polls)
                    {
                        Console.WriteLine(iterator++ + " " + "Topic name: " + item.PollName);
                    }
                    iterator = 1;
                }
                else
                {
                    throw new ArgumentNullException("No current polls!");
                }
            }
        }

    }
}