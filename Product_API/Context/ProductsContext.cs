using Microsoft.EntityFrameworkCore;
using Product_API.Data;

namespace Product_API.Context
{
    public class ProductsContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> dbContextOptions ):base (dbContextOptions)// не докінця зрозумів як працює, і навіщо ці опції
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
