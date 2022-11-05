namespace ConsoleApp1
{
	public class VotePromptConsoleService : IVotePromptService
	{
		public string PromptVoteTitle()
		{
			Console.WriteLine("Введіть Назву опитування");
			string key;
			do
			{
				key = Console.ReadLine();
			}
			while (string.IsNullOrEmpty(key));

			return key;
		}
	}
}
