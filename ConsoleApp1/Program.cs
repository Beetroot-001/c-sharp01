using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var context = new ShopContextCodeFirst();
			//var context = new ShopContextDBFirst();

            for (int i = 0; i < 3; i++)
			{
				context.Customers.Add(new Customer($"Cus{i}"));
                context.SaveChanges();
                context.EmployeePositions.Add(new EmployeePosition {	Title = $"EmpPos{i}" });
                context.SaveChanges();
                context.Employees.Add(new Employee { FirstName = $"Emp{i}", Position = context.EmployeePositions.ToList()[i] });
                context.SaveChanges();
                context.Products.Add(new Product { Title = $"Prod{i}", CreatedBy = context.Employees.ToList()[i]});
                context.SaveChanges();
                context.Orders.Add(new Order()
				{
					Products = new List<Product>() { context.Products.ToList()[i] },
					Customer = context.Customers.ToList()[i],
					Employee = new List<Employee>() { context.Employees.ToList()[i] }
				});
			}

			context.SaveChanges();
            int n = 0;
        }
	}
}