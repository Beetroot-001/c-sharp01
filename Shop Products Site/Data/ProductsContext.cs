using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop_Products_Site.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Products_Site.Data
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public ProductsContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
