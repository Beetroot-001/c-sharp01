using Microsoft.EntityFrameworkCore;
using Product_API.Data;

namespace Product_API.Context
{
    public class ProductsContext: DbContext, IDisposable
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Feedback> Feadback { get; set; }


        public ProductsContext(DbContextOptions<ProductsContext> dbContextOptions ):base (dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
