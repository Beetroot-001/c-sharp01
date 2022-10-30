using System.Text;

namespace ConsoleApp1
{
    class Vote
	{
		private string _name;
		private Dictionary<string, int> _voteOptions;

		public string Name => _name;

		public Vote(string name, int reserve)
		{
			CreateVote(name, reserve);
		}

		public void CreateVote(string name, int reserve)
		{
			Console.WriteLine($"Creating poll: {name} with {reserve} options");
			_name = name;
			_voteOptions = new Dictionary<string, int>(reserve);
            StringBuilder input = new StringBuilder();
            for (int i = 0; i < reserve; i++)
			{
				Console.WriteLine("Enter option:");
				input.Append(Console.ReadLine());
				_voteOptions.TryAdd(input.ToString(), 0);
				input.Clear();
            }
		}

		public bool TryAddVote(string op)
		{	
			if (_voteOptions.ContainsKey(op))
			{
				_voteOptions[op]++;
				return true;
			}
			return false;
		}

		public void Display()
		{
			Console.WriteLine(_name);
			foreach (var options in _voteOptions)
			{
				Console.WriteLine($" {options.Key} {options.Value}");
			}
		}

		public override int GetHashCode()
		{	
			return HashCode.Combine(_name, _voteOptions.GetHashCode());
		}

		public override bool Equals(object? obj)
		{	
			var item = obj as Vote;
			return item == null ? false : _name == item._name;
		}
	}
}