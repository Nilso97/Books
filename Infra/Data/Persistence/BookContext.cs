using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Infra.Data.Persistence
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(e =>
            {
                e.HasKey("BookId")
                    .HasName("id");

                e.Property("Author")
                    .HasColumnName("author")
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)")
                    .IsRequired(true);

                e.Property("Title")
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)")
                    .IsRequired(true);

                e.Property("BookDescription")
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)")
                    .HasColumnName("description");
            });
        }
    }
}