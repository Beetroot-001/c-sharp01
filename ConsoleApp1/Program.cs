namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Library my = new Library();

			Reader reader1 = new Reader("Vox", "Akuma");
			Reader reader2 = new Reader("Karen", "Musli");
			Reader reader3 = new Reader("Mortimer", "Goth", "K");

			Author author1 = new Author("Maria", "Maria");
			Author author2 = new Author("Color", "Sunrise");
			Author author3 = new Author("Mark", "Conners", "M");

			Book book1 = new Book("Memories", "Film", "Long sentence", author1, DateTime.Today);
			Book book2 = new Book("SQL", "Horror", "Long sentence", author2, DateTime.Today);
            Book book3 = new Book("College", "Action", "Long sentence", author3, DateTime.Today);

			my.AddBook(book1);
			my.AddBook(book2);
			my.AddBook(book3);

			my.DisplayBooks();

			my.readerCards.AddNewCard(reader1);
			my.readerCards.AddNewCard(reader2);
			my.readerCards.AddNewCard(reader3);

            my.readerCards.DisplayRecords();
			Console.WriteLine();
            my.BorrowBook(reader1, "Memories");
            my.BorrowBook(reader2, "Memories");
            my.BorrowBook(reader2, "SQL");
			my.BorrowBook(reader3, "College");
            my.BorrowBook(reader3, "Col");

			my.ReturnBook(reader3, "College");

            my.readerCards.DisplayRecords();
            my.DisplayBooks();

        }
	}
}