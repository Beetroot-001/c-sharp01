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
				if (!new[] { "1", "2", "3", "5" }.Contains(key?.Trim())){ Console.WriteLine("Error. Try again. press 5 to Exit"); continue; }
				switch (key)
                {
					case "1": {
							VoteSystem.CreateVote(); 
						} break;
					case "2": {
							VoteSystem.VoteMenu(); 
						} break;
					case "3": {
							VoteSystem.ShowResults(); 
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


	}
}