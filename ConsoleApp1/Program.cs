namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				DrawMenu();
				var key = Console.ReadLine();
				if (!new[] { "1", "2", "3", "5" }.Contains(key.Trim())){ Console.WriteLine("Error. Try again. press 5 to Exit"); continue; }
				switch (key)
                {
					case "1": { 
							CreateVote(); 
						} break;
					case "2": { 
							VoteMenu(); 
						} break;
					case "3": { 
							ShowResults(); 
						} break;
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

		public static void CreateVote()
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
				if (string.IsNullOrEmpty(key)) {
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
			

			Vote.votes.Add(vote);
		}

		public static void VoteMenu()
		{
			string key = string.Empty;
			Console.WriteLine("Виберіть опитування");
            for (int i = 0; i < Vote.votes.Count; i++)
            {
				Vote vote = Vote.votes[i];
				Console.WriteLine($"{i}.{vote.Title}");
            }
			key = Console.ReadLine();
		}

		public static void ShowResults()
		{
			string key = string.Empty;
			Console.WriteLine("Виберіть опитування");
			for (int i = 0; i < Vote.votes.Count; i++)
			{
				Vote vote = Vote.votes[i];
				Console.WriteLine($"{i}.{vote.Title}");
			}
		}
	}
}