
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var context = new ShopContext();
            // query

            context.Orders.Add(new Order
			{
				OrderId = new Guid(),
				Products = new List<Product>()
				{
					new Product
					{
						ProductId = new Guid(),
						Title = "Orange",
						Type = new Type
						{
							//TypeId = 1,
							FullTitle = "Fruit"
						}
                    },
                    new Product
					{
                        ProductId = new Guid(),
                        Title = "Apple",
                        Type = new Type
                        {
                            //TypeId = 2,
                            FullTitle = "Red"
                        }
                    },
					new Product
					{
                        ProductId = new Guid(),
                        Title = "Honey",
                        Type = new Type
                        {
                           // TypeId = 3,
                            FullTitle = "Sweets"
                        }
                    }
				},
                Employee = new Employee 
				{
                    EmployeeId = new Guid(),
					FirstName = "John",
					LastName = "Helbic"
                },
				Customer = new Customer 
				{
                    CustomerId = new Guid(),
                    FirstName = "G",
                    LastName = "Holic",
					Rating = 5
                }
            });

			context.SaveChanges();
		}

    }
}