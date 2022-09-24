namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Reader person1 = new Reader ("Alex", "Xanter", 342435, new DateTime (1991,6,22));
			Reader person2 = new Reader ("Petr", "Glance", 674675, new DateTime (1981,7,2));

			LibraryCard card1 = new LibraryCard(person1);
			LibraryCard card2 = new LibraryCard(person2);

			Book book1 = new Book(new Author("Dmitro Gluhovskii", "A very nice author"), "Metro2033", "Post-apocalyptic novel about Moscov metro", new[] { "chapter1", "chapter2", "chapter3" });
			Book book2 = new Book(new Author("Korney Chukovskii", "A very nice author"), "Tarakanishe", "Post-apocalyptic novel about Moscov metro", new[] { "chapter1" });

			
			
			Library.AddBook(book1, book2);

			


			card1.AssignBook("metro");
			
		}
	}
}