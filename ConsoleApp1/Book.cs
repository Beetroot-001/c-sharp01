using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
	public class Book
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int GenreId { get; set; }
		public Genre Genre { get; set; }
		public ICollection<Author> Authors { get;set; }

		#region Audit fields

		public DateTime CreatedOn { get; set; }
		#endregion
	}
}
