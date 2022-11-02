using System.Linq;

namespace ConsoleApp1
{
	public interface IVoteRepository
	{
		ICollection<Vote> GetAllVotes();

		/// <summary>
		/// Finds vote by title
		/// </summary>
		/// <param name="title">Vote title</param>
		/// <returns>Vote or null if not found</returns>
		Vote GetVoteByTitle(string title);
	}


	public class VoteSystem
	{
		private readonly IVotePromptService votePromptService;
		private readonly IVoteRepository voteRepository;

		public IList<Vote> Votes { get; }

		public VoteSystem(IVotePromptService votePromptService, IVoteRepository voteRepository)
		{
			this.votePromptService = votePromptService;
			this.voteRepository = voteRepository;
			Votes = null;
		}

		public void ShowVote(int voteId)
		{
			string key = string.Empty;
			Console.WriteLine($"Title: {Votes[voteId].Title}");
			foreach (var question in Votes[voteId].Questions)
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



		public void CreateVote()
		{
			var key = votePromptService.PromptVoteTitle();

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


			AddVote(vote);
		}

		private void AddVote(Vote vote)
		{
			Votes.Add(vote);
		}

		public void VoteMenu()
		{
			string key = string.Empty;
			Console.WriteLine("Виберіть опитування. Введіть його номер. Або введіть х щоб повернутись назад");
			for (int i = 0; i < Votes.Count; i++)
			{
				Vote vote = Votes[i];
				Console.WriteLine($"{i}.{vote.Title}");
			}
			do
			{
				key = Console.ReadLine() ?? "";
				if (key == "x")
				{
					continue;
				}

				if (!int.TryParse(key, out int voteId) || voteId > Votes.Count - 1)
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
			foreach (var vote in Votes)
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


		public void CreateVoteV2(string title)
		{
			// "vote title" "Vote title"
			
			var vote = new Vote(title);
			var existedVote = voteRepository.GetVoteByTitle(title);
			if (existedVote != null)
			{
				throw new VoteDuplicatedException(title);
			}

			// if current DateTime not work time throw exception

			Votes.Add(vote);
		}
	}

	public class VoteDuplicatedException : Exception
	{
		public VoteDuplicatedException(string title) : base($"Vote with title {title} is already existing")
		{

		}
	}

}
