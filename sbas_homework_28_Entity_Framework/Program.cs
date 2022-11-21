using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace sbas_homework_28_Entity_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Declare models for ‘shop’ domain including:

                customers
                employees
                products
                orders

            Declare db context, create migrations, try to query and save data using EF
            */

            ShopContext context = new ShopContext();

            context.Employees.AddRange
                (
                  new Employees() { FirstName = "Serhii", LasttName = "Bas", EmployeesPhoneNuber = 38000000000, EmployeesId = Guid.NewGuid() },
                  new Employees() { FirstName = "Employees 1", LasttName = "LasttName 1", EmployeesPhoneNuber = 380234033, EmployeesId = Guid.NewGuid() },
                  new Employees() { FirstName = "Employees 2", LasttName = "LasttName 2", EmployeesPhoneNuber = 3812345561},
                  new Employees() { FirstName = "Employees 3", LasttName = "LasttName 3", EmployeesPhoneNuber = 3812340}
                );
            context.SaveChanges();

            context.Products.AddRange
                (
                new Product() { Data = "Aple", Prise = 1234 },
                new Product() { Data = "phone", Prise = 2222},
                new Product() { Data = "Pan", Prise = 3333 },
                new Product() { Data = "Melon", Prise = 4444 }
                );

            context.SaveChanges();

            context.Customers.AddRangeAsync
                (
                     new Customer() { FirstName = "FirstName 1", LasttName = "LasttName 1" },
                     new Customer() { FirstName = "FirstName 2", LasttName = "LasttName 2" },
                     new Customer() { FirstName = "FirstName 3", LasttName = "LasttName 3" },
                     new Customer() { FirstName = "FirstName 4", LasttName = "LasttName 4" }

                );
            context.SaveChangesAsync();

            context.Orders.AddRangeAsync // додаємо масив елементів до Orders
                (
                    new Order() { Customers = context.Customers.ToList()[1],Employees = context.Employees.ToList()[1], Products = new List<Product>() {context.Products.ToList()[1]}},// витягуємо елементи з таблиць
                    new Order() { Customers = context.Customers.ToList()[2],Employees = context.Employees.ToList()[2]},
                    new Order() { Customers = context.Customers.ToList()[3],Employees = context.Employees.ToList()[3]}
                );
            context.SaveChanges();

            var OrdersInclude = context.Orders.Include(x => x.Customers).Include(x => x.Products).Where(x => x.OrderId!=null).ToList();// Визначаю що конкретно хочу бачити

            context.SaveChanges();
            

        }
    }
}