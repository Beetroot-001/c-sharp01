using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class ShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var CustomerModel = modelBuilder.Entity<Customer>();

            CustomerModel.HasKey(x => x.Id);
            CustomerModel.Property(x => x.Name).
                IsRequired(true).
                HasMaxLength(100);
            CustomerModel.Property(x => x.Phone).
                IsRequired(true).
                HasMaxLength(13);

            var EmployeeModel = modelBuilder.Entity<Employee>();

            EmployeeModel.HasKey(x => x.Id);
            EmployeeModel.Property(x => x.Name).
                IsRequired(true).
                HasMaxLength(100);
            EmployeeModel.Property(x => x.Phone).
                IsRequired(true).
                HasMaxLength(100);

            var ProductModel = modelBuilder.Entity<Product>();

            ProductModel.HasKey(x => x.Id);
            ProductModel.Property(x => x.Name).
                IsRequired(true).
                HasMaxLength(100);
            ProductModel.Property(x => x.InStock).
                IsRequired(true);
            ProductModel.Property(x => x.Prise).
                IsRequired(true);

            var OrderModel = modelBuilder.Entity<Order>();

            OrderModel.HasKey(x => x.Id);
            OrderModel.HasOne(x => x.Customer).
                WithMany().
                HasForeignKey(x => x.CustomerId).
                IsRequired(true);
            OrderModel.HasOne(x => x.Product).
                WithMany().
                HasForeignKey(x => x.ProductId).
                IsRequired(true);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Shop;Trusted_Connection=True;");
        }
    }
}
