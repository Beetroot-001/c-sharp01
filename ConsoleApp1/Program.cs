using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using var context = new LibraryContext();

			context.Genres.AddRange(new[] {
				new Genre { Title = "Horror" },
				new Genre { Title = "Comedy" },
			});

			context.SaveChanges();

			//context.Books.Add(new Book
			//{
			//    CreatedOn = DateTime.Now,
			//    Description = null,
			//    Genre = new Genre()
			//    {
			//        Title = 
			//        Title = "Horror"
			//    },
			//    Title = "Horror book",
			//    Authors = new List<Author>(){
			//        new Author(){
			//            FirstName = "Steven",
			//            LastName = "King"
			//        }
			//    }
			//});

			context.SaveChanges();

			var books = context.Books.ToList();

			var filteredBooks = context.Books
				.Include(x => x.Genre).Include(x => x.Authors)
				.Where(x => x.Authors.Count() == 1)
				.ToList();


			Genre? comedy = context.Genres.First(x => x.Id == 2);

			var newBook = context.Books.Add(
				new Book
				{
					Genre = comedy,
					CreatedOn = DateTime.Now,
					Title = "New title"
				});

			context.SaveChanges();

			var book = context.Books.Where(x => x.GenreId == 2).FirstOrDefault();
			book.Title += "2";
			context.SaveChanges();

			context.Remove(book);
			context.SaveChanges();
		}
	}
}