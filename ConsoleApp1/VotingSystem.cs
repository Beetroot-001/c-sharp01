namespace ConsoleApp1
{
    class VotingSystem 
	{
		private Dictionary<string, Vote> _votes;

		public VotingSystem(int reserve = 3)
		{
			_votes = new Dictionary<string, Vote>(reserve);
		}

		public void DisplayAll()
		{
			foreach (var vote in _votes)
			{
				vote.Value.Display();
			}
		}

		public void CreatePoll()
		{
			Console.Write("Enter title of a new pole: ");
			string name = Console.ReadLine() ?? "default1";
			Console.WriteLine("How many options? : ");
			int reserve;
			InputParse.TryIntInput(out reserve);
			_votes.TryAdd(name, new Vote(name, reserve));
        }

		public bool Voting()
		{
			if (_votes.Count == 0)
			{
				Console.WriteLine("No polles to vote for! Try creating one");
				return false;
			}
			Console.WriteLine("Polles and Options: ");
			DisplayAll();
			Console.Write("Enter poll name: ");
			string? name = Console.ReadLine() ?? "default";
			Console.Write("Enter option: ");
			string? option = Console.ReadLine() ?? "default";
			if (_votes.ContainsKey(name))
			{
                return _votes[name].TryAddVote(option);
            }
			return false;
		}
	}
}