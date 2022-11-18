using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ShopContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        

        public ShopContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var customerModel = modelBuilder.Entity<Customer>();
            customerModel.HasKey(x => x.CustomerId);
            customerModel.Property(x => x.FirstName).IsRequired(true).HasMaxLength(20).IsUnicode();
            customerModel.Property(x => x.LastName).IsRequired(true).HasMaxLength(20).IsUnicode();
            customerModel.HasMany(x => x.OrderId).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).IsRequired(false);
            customerModel.Property(x => x.Rating).HasDefaultValue(5);

            var productModel = modelBuilder.Entity<Product>();
            productModel.HasKey(x => x.ProductId);
            productModel.HasMany(x => x.OrderId).WithMany(x => x.Products);
            productModel.Property(x => x.Title).IsRequired(true).HasMaxLength(15).IsUnicode();
            productModel.Property(x => x.TypeId).IsRequired(true);
            productModel.Property(x => x.Quantity).IsRequired(true).HasDefaultValue(1);
            productModel.HasOne(x => x.Type).WithMany().HasForeignKey(x => x.TypeId).IsRequired(true);
            
            var employeeModel = modelBuilder.Entity<Employee>();
            employeeModel.HasKey(x => x.EmployeeId);
            employeeModel.HasMany(x => x.OrderId).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
            employeeModel.Property(x => x.FirstName).IsRequired(true).HasMaxLength(20).IsUnicode();
            employeeModel.Property(x => x.LastName).IsRequired(true).HasMaxLength(20).IsUnicode();
            employeeModel.Property(x => x.Rating).HasDefaultValue(3);

            var orderModel = modelBuilder.Entity<Order>();
            orderModel.HasKey(x => x.OrderId);
            orderModel.HasMany(x => x.Products).WithMany(x => x.OrderId);
            orderModel.Property(x => x.SendDate).IsRequired(true);

            var typeModel = modelBuilder.Entity<Type>();
            typeModel.HasKey(x => x.TypeId);
            typeModel.Property(x => x.FullTitle).IsRequired(true).HasMaxLength(20).IsUnicode();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Shop;Trusted_Connection=True;");
        }
    }
}
