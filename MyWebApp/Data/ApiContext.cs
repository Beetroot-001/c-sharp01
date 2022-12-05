using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Animatronic> Animatronics {get; set;}

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
