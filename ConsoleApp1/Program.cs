namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Library my = new Library();

			my.AddBook(new Book("Loli", "ection", "my desc", new Author("Lilit", "Becker", "Auf"), DateTime.Today, 3));
		}
	}
}