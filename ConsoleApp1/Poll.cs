using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Poll
    {
        public string PollName { get; private set; }
        public string PollQuestion { get; private set; }
        public List<Variant> variants { get; private set; } = new List<Variant>();
        public int VotesYay { get; private set; }
        public int VotesNay { get; private set; }
        public enum MyEnum
        {
            Single,
            Complex
        }
        public MyEnum my;
        public Poll()
        {
            Console.WriteLine("Simple(1) or Complex(2) poll?");
            int choice = Program.Menu.Parser(Console.ReadLine());
            my = choice == 1 ? MyEnum.Single : MyEnum.Complex;
            if (my == MyEnum.Single)
            {
                Console.WriteLine("Enter name of the poll: ");
                PollName = Console.ReadLine();
                Console.WriteLine("Enter topic of the poll: ");
                PollQuestion = Console.ReadLine();
                VotesYay = 0;
                VotesNay = 0;
            }
            else
            {
                Console.WriteLine("Enter name of the poll: ");
                PollName = Console.ReadLine();
                Console.WriteLine("Enter topic of the poll: ");
                PollQuestion = Console.ReadLine();
                Console.WriteLine("Choose num of variants: ");
                while (true)
                {
                    int num = Program.Menu.Parser(Console.ReadLine());
                    if (num > 1)
                    {
                        AddVariant(num);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("We're long past comunism, choose an adequate number of variants!");
                    }
                }
            }
        }
        public void AddVariant(int numOfVar)
        {
            for (int i = 0; i < numOfVar; i++)
            {
                Console.WriteLine("Enter variant: ");
                Variant variant = new(Console.ReadLine());
                variants.Add(variant);
            }
        }
        public void Vote(bool yOrN)
        {
            int i = (yOrN == true) ? VotesYay++ : VotesNay++;
            Console.WriteLine("Voted!");
        }
        public void Vote(Variant var)
        {
            var.Votes++;
            Console.WriteLine("Voted!");
        }
        public void ShowResults()
        {
            if (my == MyEnum.Single)
            {
                Console.WriteLine($"{PollQuestion} got yes votes: {VotesYay} and {VotesNay} no votes");
            }
            else
            {
                foreach (var item in variants)
                {
                    Console.WriteLine(item.Topic + $" has {item.Votes} votes"); 
                }
            }

        }
    }

    public class Variant
    {
        public string Topic { get; private set; }
        public int Votes { get; set; }
        public Variant(string topic)
        {
            Topic = topic;
            Votes = 0;
        }
    }
}
