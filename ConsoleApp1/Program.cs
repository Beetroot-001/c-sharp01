namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Author ukr1 = new Author("Taras", "Shevchenko", "The Greatest ukrainian poet");
			Author ukr2 = new Author("Ivan", "Franko");
			Author ukr3 = new Author("Grygorii", "Skovoroda");
			Author ukr4 = new Author("Lesya", "Ukrainka");
			Author ukr5 = new Author("Ostap", "Vyshnya");
			Console.WriteLine(ukr1.DisplayName() + " || " + ukr1.AboutInfo);
			Console.WriteLine(ukr2.DisplayName() + " || " + ukr2.AboutInfo);
			Console.WriteLine(ukr3.DisplayName() + " || " + ukr3.AboutInfo);
			Console.WriteLine(ukr4.DisplayName() + " || " + ukr4.AboutInfo);
			Console.WriteLine(ukr5.DisplayName() + " || " + ukr5.AboutInfo);


			Book warAndPeace = new Book("War And Peace", "The roman about interactions on the War in Europe in 1812", new ("Leo", "Tolstoy"), 1225);
			Book forestSong = new Book("Forest Song", "The fantastic drama is three acts and was written in 1911 by Lesya Ukrainka", ukr4, 94);
			Book tigerTrappers = new Book("Tiger Trappers", "A romantic adventure that intertwines the autobiographical facts of the author Ivan Bahrianyi", new("Ivan", "Bahrianyi"), 304);
			Book test = new Book("TEST", "description", new("Andrii","Kovalenko"), 10);

			Library library = new Library();
			library.AddBook(tigerTrappers, 1);
			library.AddBook(forestSong, 2);
			library.AddBook(warAndPeace, 3);
			library.AddBook(test, 1);

			library.DisplayAllAvailableBooksList(library.Books);

			Console.WriteLine("[SEARCH] Please enter a bookName or Author or description or countOfpages");
			string inStr = Console.ReadLine().ToLowerInvariant().Trim();

			Console.WriteLine(library.SearchBook(inStr).Title);

			Console.WriteLine("[DELETE] Please enter a bookName (or Author or description or countOfpages) TO DELETE");
			string inStr2 = Console.ReadLine().ToLowerInvariant().Trim();
			library.DeleteBook(inStr2, library.Books);

			library.DisplayAllAvailableBooksList(library.Books);

			Console.WriteLine("[DELETE] Please enter a bookName (or Author or description or countOfpages) TO DELETE");
			string inStr3 = Console.ReadLine().ToLowerInvariant().Trim();
			library.DeleteBook(inStr3, library.Books);

			library.DisplayAllAvailableBooksList(library.Books);

		}
	}
}