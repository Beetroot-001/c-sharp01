using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Animatronic> Animatronics {get; set;}

        public ApiContext(DbContextOptions<ApiContext> dbContextOptions) : base(dbContextOptions)
        {
           Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
