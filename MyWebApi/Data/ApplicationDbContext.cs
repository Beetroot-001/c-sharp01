using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Person> People { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
			: base(dbContextOptions)
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().HasKey(p => p.Id);
			modelBuilder.Entity<Person>().Property(x => x.FirstName).IsRequired().HasMaxLength(50).IsUnicode();
			modelBuilder.Entity<Person>().Property(x => x.LastName).IsRequired().HasMaxLength(50).IsUnicode();

			modelBuilder.Entity<Person>().Property(x => x.Age).IsRequired();


			modelBuilder.Entity<Person>().HasMany(x => x.Friends).WithMany(x => x.Friends);
			modelBuilder.Entity<Person>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
		}
	}
}
