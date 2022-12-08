using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ShopContextCodeFirst : DbContext
    {
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopContextCodeFirst()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var EmployeePositionModel = modelBuilder.Entity<EmployeePosition>();
            //EmployeePositionModel.Property(e => e.Id).ValueGeneratedOnAdd();

            //var shopModel = modelBuilder.Entity<Order>();
            //shopModel.HasKey(x => x.Id);
            //shopModel.HasOne(x => x.Employee).WithMany(x => x.OrdersCompleted);
            //shopModel.HasOne(x => x.CreatedBy).WithMany(x => x.OrdersCompleted);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Shop;Trusted_Connection=True;");
        }
    }
}
