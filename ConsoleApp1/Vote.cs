using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Vote : Base
    {
        public static List<Vote> votes  { get; set; } = new List<Vote>()
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

        public List<Question> Questions { get; set; } = new List<Question>();

        public Vote(string title)
        {
            Title = title;
        }

        public static void ShowVote(int voteId)
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
                    if(answerId > question.Answers.Count - 1)
                    {
                        Console.WriteLine("Нема варіанту з таким номером");
                    }
                } while (!(int.TryParse(key, out answerId) && answerId <= question.Answers.Count - 1));
                question.Answers[answerId].Count++;
                
            }
        }
    }
}
