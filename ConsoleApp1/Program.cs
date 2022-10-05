namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] tableOfContent = new string[] { "The Boy Who Lived","The Vanishing Glass","The Letters from No One","The Keeper of the Keys" };
			Books HarryPotter = new Books("J.K. Rowling", "Harry Potter and the Philosopher's Stone","A beloved story about the life of a young wisard boy learning to be a magician",1997,tableOfContent);
			Books TheLittlePrince = new Books("Antoine de Saint-Exupery","The Little Prince","A novella for kids that describes how adults are moorons",1943);

			Readers serhiiBas = new Readers("Serhii", "Bas", 26, "Ukraine");

			Library library = Library.InitOrGetLibrary();

            ReaderСard readerСardSerhii = new ReaderСard(serhiiBas);

			readerСardSerhii.AddReadBook(HarryPotter);
			readerСardSerhii.AddReadBook(TheLittlePrince);

			library.AddReaderСard(readerСardSerhii);
			library.AddBooks(HarryPotter);
			library.AddBooks(TheLittlePrince);

			library.GetAllReadersСards();
			Console.WriteLine("---------------ALL BOOKS--------------");
			library.GetAllLibraryBooks();

			Console.ReadLine();
		}
	}
}