using Newtonsoft.Json;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
        {
			var library = new Library();
			Library.CreateTempBooks(library);
			Library.CreateTempUserCards(library);
			var userCard = library.UserCards[new Random().Next(0, library.UserCards.Count)];			
		}
	}
}