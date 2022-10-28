namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var shop = new Shop
			{
				Owner = new Person
				{
					FullName = "A b"
				},
				Title = "This is super Shop",
				Products = new List<Product>
				{
					new Product
					{
						Id = Guid.NewGuid(),
						Name = "Apple",
						ExpiredDate = DateTime.Now.AddDays(7),
						Quantity = 10,
						UnitPrice = 10.5m
					}
				}
			};

		}
	}

	public class Shop
	{
		public string Title { get; set; }
		public ICollection<Product> Products { get; set; }

		public Person Owner { get; set; }
	}

	public class Person
	{
		public string FullName { get; set; }
	}

	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public DateTime ExpiredDate { get; set; }

		public bool IsAvailable => Quantity > 0;
	}
}