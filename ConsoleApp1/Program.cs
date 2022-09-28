using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Reader person1 = new Reader ("Alex", "Xanter", "342435", new DateTime (1991,6,22));
			Reader person2 = new Reader ("Petr", "Glance", "674675", new DateTime (1981,7,2));

			LibraryCard card1 = new LibraryCard(person1);
			LibraryCard card2 = new LibraryCard(person2);

			Book book1 = new Book(new Author("Dmitro Gluhovskii", "A very nice author"), "Metro2033", "Post-apocalyptic novel about Moscov metro", new[] { "chapter1", "chapter2", "chapter3" });
			Book book2 = new Book(new Author("Korney Chukovskii", "A very nice author"), "Tarakanishe", "Post-apocalyptic novel about Moscov metro", new[] { "chapter1" });
			Book book3 = new Book(new Author("Arkady and Boris Strugatsky", "A very nice author"), "The Inhabited Island", "The protagonist is a youngster, Maxim Kammerer, who comes from the version of Earth that exists in the Noon Universe and gets stranded on an unknown planet named Saraksh.", new[] { "chapter1" });
			Book book4 = new Book(new Author("George Orwell", "A very nice author"), "1984", " 1984 is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", new[] { "chapter1" });
			Book book5 = new Book(new Author("Ray Bradbury", "A very nice author"), "Fahrenheit 451", "Fahrenheit 451 presents an American society where books have been outlawed and \"firemen\" burn any that are found.", new[] { "chapter1" });		

			Library.AddBook(book1, book2,book3,book4, book5);
			bool exit = false;
			Library.AddCard(card1,card2);

			int query = 0;
            Library.DisplayMenu();
            while (!exit)
			{
				query = int.Parse(Console.ReadLine());

				switch (query)
				{
					case 0:
						exit = true;
						break;
					case 1:
						Library.TakeBook();
                        break;
					case 2:
						Library.AddNewReader();
						break;
                    case 3:
						Library.DeleteReaderCard();
                        break;
                    case 4:
						Library.AddBook();
						break;
					case 5:
						Library.ShowBooks();
                        break;
                }
			}


        }
    }
}