namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using var context = new ShopContext();

			context.Customers.AddRange(new[]
			{
				new Customer { Name = "Cust1", Phone = "CustPh1"},
                new Customer { Name = "Cust2", Phone = "CustPh2"}
            });

            context.SaveChanges();

            context.Employees.AddRange(new[] 
			{ 
				new Employee { Name = "Emp1", Phone = "EmpPh1"},
                new Employee { Name = "Emp2", Phone = "EmpPh2"}
            });

            context.SaveChanges();

            context.Products.Add(
				new Product 
				{ 
					Name = "Prod1", 
					InStock = 10, 
					Prise = 16.5f 
				});

            context.SaveChanges();

            Customer? customer = context.Customers.First(x => x.Id == 1);
			Product? product = context.Products.First(x => x.Id == 1);

			context.Orders.Add(
				new Order 
				{
					Customer = customer,
					Product = product
				});

			context.SaveChanges();
		}
	}
}