using Microsoft.EntityFrameworkCore;
using SimpleServer.Models;

namespace SimpleServer.Context
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> People { get; init; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }
    }
}
