using Microsoft.EntityFrameworkCore;
using MyFirstSite.Models;

namespace MyFirstSite.Data
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PeopleContext()
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
