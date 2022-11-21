using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbas_homework_28_Entity_Framework
{
    internal class ShopContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Class1> Class1s { get; set; }

        public ShopContext()
        {
            Database.EnsureCreated();// перевірити чи існує БД та вразі її відсутності створює її
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // використовується для сворення обмажень на стовпці
        {
            base.OnModelCreating(modelBuilder);

            var ProdactModel = modelBuilder.Entity<Product>();

            ProdactModel.HasKey(x => x.ProductId);// якщо тип даних Guid і так відбувається автоматичне генерування по замовчкванню
            ProdactModel.Property(x => x.Data).IsRequired(true);
            ProdactModel.Property(x => x.Prise).IsUnicode(true).IsRequired(true);

            var EmployeesModel = modelBuilder.Entity<Employees>();

            EmployeesModel.HasKey(x => x.EmployeesId);
            EmployeesModel.Property(x => x.FirstName).IsUnicode(true).IsRequired(true).HasMaxLength(20);
            EmployeesModel.Property(x => x.LasttName).IsRequired(true).HasMaxLength(30);

            var CustomerModel = modelBuilder.Entity<Customer>();

            CustomerModel.Property(x => x.FirstName).IsRequired(true).HasDefaultValue("Default").HasDefaultValue(30);
            CustomerModel.Property(x => x.LasttName).IsRequired(true).HasMaxLength(30).HasDefaultValue("Default");
            CustomerModel.Property(x => x.CustomersPhoneNuber).ValueGeneratedOnAdd();
            CustomerModel.HasKey(x => x.CustomersId);

            var OrderModel = modelBuilder.Entity<Order>();

            OrderModel.HasKey(x => x.OrderId);
            OrderModel.HasMany(x => x.Products).WithMany();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)// обов'язково protected
        {
            dbContextOptionsBuilder.UseSqlServer("Server=localhost;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True");// 1. Сервер 2. БД 3. підключатися 
        }
    }
}
