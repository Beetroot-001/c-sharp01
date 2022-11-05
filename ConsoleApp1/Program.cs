namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var initialVotes = new List<Vote>()
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


			var voteSystem = new VoteSystem(null, null);
			Dictionary<string, Action> keyMethodsDict = new Dictionary<string, Action>()
			{
				{"1", ()=>{ voteSystem.CreateVote(); } },
				{"2", ()=>{ voteSystem.VoteMenu(); } },
				{"3", ()=>{ voteSystem.ShowResults(); } },
				{"5", ()=>{ Environment.Exit(1); } },
			};


			while (true)
			{
				DrawMenu();
				var key = Console.ReadLine();
				if (key is not null && !keyMethodsDict.ContainsKey(key?.Trim())) { Console.WriteLine("Error. Try again. press 5 to Exit"); continue; }

				keyMethodsDict[key]();
			}
		}

		 

		public static void DrawMenu()
		{
			Console.WriteLine("Menu");
			Console.WriteLine("1.Створити опитування");
			Console.WriteLine("2.Проголосувати");
			Console.WriteLine("3.Подивитись результати");
		}
	}
}