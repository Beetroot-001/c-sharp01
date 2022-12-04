using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopProductsWebApp.Models;

namespace ShopProductsWebApp.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext (DbContextOptions<ProductsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=ProductDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
