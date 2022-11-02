using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class VoteSystem
    {
        public static List<Vote> votes { get; set; } = new List<Vote>()
            {
                new Vote("v1"){
                    Questions = new List<Question>()
                    {
                        new Question("q1"){
                            Answers = new List<Answer>()
                            {
                                new Answer("ans1"),
                                new Answer("ans2"),
                                new Answer("ans3"),
                            }
                        }
                    }
                },
                new Vote("v2"){
                    Questions = new List<Question>()
                    {
                        new Question("q1"){
                            Answers = new List<Answer>()
                            {
                                new Answer("ans1"),
                                new Answer("ans2"),
                                new Answer("ans3"),
                            }
                        },
                        new Question("q2"){
                            Answers = new List<Answer>()
                            {
                                new Answer("ans1"),
                                new Answer("ans2"),
                                new Answer("ans3"),
                            }
                        }
                    }
                },
                new Vote("v3"){
                    Questions = new List<Question>()
                    {
                        new Question("q1"){
                            Answers = new List<Answer>()
                            {
                                new Answer("ans1"),
                                new Answer("ans2"),
                                new Answer("ans3"),
                            }
                        },
                        new Question("q2"){
                            Answers = new List<Answer>()
                            {
                                new Answer("ans1"),
                                new Answer("ans2"),
                                new Answer("ans3"),
                            }
                        },
                        new Question("q2"){
                            Answers = new List<Answer>()
                            {
                                new Answer("ans1"),
                                new Answer("ans2"),
                                new Answer("ans3"),
                            }
                        }
                    }
                },
            };

        public void ShowVote(int voteId)
        {
            string key = string.Empty;
            Console.WriteLine($"Title: {votes[voteId].Title}");
            foreach (var question in votes[voteId].Questions)
            {
                Console.WriteLine($"Питання: {question.Title}");
                Console.WriteLine("Варіанти:");
                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.WriteLine($"{i}.{question.Answers[i].Title}");
                }

                int answerId;
                do
                {
                    Console.WriteLine("Введіть номер відповіді");
                    key = Console.ReadLine() ?? "";

                    if (!int.TryParse(key, out answerId))
                    {
                        Console.WriteLine("Некоректний ввід");
                        continue;
                    }
                    if (answerId > question.Answers.Count - 1)
                    {
                        Console.WriteLine("Нема варіанту з таким номером");
                    }
                } while (!(int.TryParse(key, out answerId) && answerId <= question.Answers.Count - 1));
                question.Answers[answerId].Count++;
            }
        }

        public void AddVote(Vote vote)
        {
            votes.Add(vote);
        }

        public void CreateVote()
        {
            string key = string.Empty;
            Console.WriteLine("Введіть Назву опитування");
            do
            {
                key = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(key));

            var vote = new Vote(key);

            do
            {
                Console.WriteLine("Ввести Питання.  для завершення введіть х");
                key = Console.ReadLine();
                if (string.IsNullOrEmpty(key))
                {
                    Console.WriteLine("Error");
                    continue;
                }
                if (key.ToLower() != "x" && key.ToLower() != "х")
                {
                    var question = new Question(key);

                    Console.WriteLine("Введіть Варіанти відповідей. для завершення введіть х");
                    do
                    {
                        key = Console.ReadLine();
                        if (string.IsNullOrEmpty(key))
                        {
                            Console.WriteLine("Error");
                            continue;
                        }
                        if (key.ToLower() != "x" && key.ToLower() != "х")
                        {
                            var answer = new Answer(key);
                            question.Answers.Add(answer);
                        }
                    }
                    while (key.ToLower() != "x" && key.ToLower() != "х");

                    vote.Questions.Add(question);

                    Console.WriteLine("Додати ще питання? так/ні");
                    if (Console.ReadLine() == "так") key = "";
                }
            } while (key.ToLower() != "x" && key.ToLower() != "х");


            VoteSystem.AddVote(vote);
        }

        public void VoteMenu()
        {
            string key = string.Empty;
            Console.WriteLine("Виберіть опитування. Введіть його номер. Або введіть х щоб повернутись назад");
            for (int i = 0; i < VoteSystem.votes.Count; i++)
            {
                Vote vote = VoteSystem.votes[i];
                Console.WriteLine($"{i}.{vote.Title}");
            }
            do
            {
                key = Console.ReadLine() ?? "";
                if (key == "x")
                {
                    continue;
                }

                if (!int.TryParse(key, out int voteId) || voteId > VoteSystem.votes.Count - 1)
                {
                    Console.WriteLine("Error. Некоректний ввід або число перевищує кількість опитувань");
                    Console.WriteLine("Виберіть опитування. Введіть його номер");
                    continue;
                }

                ShowVote(voteId);
            } while (key.ToLower() != "x" && key.ToLower() != "х");
        }

        public void ShowResults()
        {
            foreach (var vote in VoteSystem.votes)
            {
                Console.WriteLine($"{vote.Title}");
                foreach (var question in vote.Questions)
                {
                    Console.WriteLine($"  {question.Title}");
                    foreach (var answer in question.Answers)
                    {
                        Console.WriteLine($"    {answer.Title}::{answer.Count}");
                    }
                }
            }
        }
    }
}
