namespace ConsoleApp1
{
    static class Menu
	{
		static VotingSystem votingSystem = new VotingSystem();

        public static void Start()
		{
			Console.WriteLine();
			Console.WriteLine(" --- MENU --- ");
			Console.WriteLine("1. Create poll");
			Console.WriteLine("2. Vote");
			Console.WriteLine("3. Show all polls and results");
			int option;
			InputParse.TryIntInput(out option);
			switch (option)
			{
				case 1:
					Console.WriteLine("Create poll!");
					votingSystem.CreatePoll();
					Start();
                    break;
			    case 2:
					Console.WriteLine("Voting!");
					votingSystem.Voting();
					Start();
					break;
				case 3:
					Console.WriteLine("Polls and results: ");
					votingSystem.DisplayAll();
					Start();
					break;
				default:
					Start();
					break;
			}
		}
	}
}