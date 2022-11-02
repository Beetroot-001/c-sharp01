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

			while (true)
			{
				DrawMenu();
				var key = Console.ReadLine();
				if (!new[] { "1", "2", "3", "5" }.Contains(key?.Trim())) { Console.WriteLine("Error. Try again. press 5 to Exit"); continue; }
				switch (key)
				{
					case "1":
						{
							voteSystem.CreateVote();
						}
						break;
					case "2":
						{
							voteSystem.VoteMenu();
						}
						break;
					case "3":
						{
							voteSystem.ShowResults();
						}
						break;
					default:
						System.Environment.Exit(1);
						break;
				}
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