using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public LibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bookModel = modelBuilder.Entity<Book>();
            bookModel.HasKey(x => x.Id);
            bookModel.Property(x => x.Description).IsRequired(false).IsUnicode(false);
            bookModel.Property(x => x.Title).IsRequired(true).HasMaxLength(50);

            bookModel.HasMany(x => x.Authors).WithOne().HasForeignKey(x => x.BookId).IsRequired(false);
            bookModel.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId);

            var authorModel = modelBuilder.Entity<Author>();

            authorModel.HasKey(x => x.Id);
            authorModel.Property(x => x.FirstName).IsRequired().HasMaxLength(40);
            authorModel.Property(x => x.LastName).IsRequired().HasMaxLength(40);

            var genreModel = modelBuilder.Entity<Genre>();
            genreModel.HasKey(x => x.Id);
            genreModel.Property(x => x.Title).IsRequired();
            genreModel.ToTable("Genre");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Library;Trusted_Connection=True;");
        }
    }
}
