using Microsoft.EntityFrameworkCore;
using GerenciamentoLivros.Entities;

namespace GerenciamentoLivros.Data;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Author
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            entity.Property(e => e.Nationality).HasMaxLength(30);
        });

        // Genre
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
        });

        // Book
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(30);
            entity.Property(e => e.Synopsis).HasMaxLength(150);
            entity.Property(e => e.ISBN).HasMaxLength(20);
            entity.Property(e => e.Edition).HasMaxLength(15);
            entity.Property(e => e.PublicationYear);
            entity.HasOne(e => e.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(e => e.IdAuthor)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(e => e.IdGenre)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Seed Authors
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "J. K. Rowling", Nationality = "British", CreationDate = DateTime.UtcNow },
            new Author { Id = 2, Name = "George R. R. Martin", Nationality = "American", CreationDate = DateTime.UtcNow }
        );

        // Seed Genres
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Fantasy", Description = "Fantasy books", CreationDate = DateTime.UtcNow },
            new Genre { Id = 2, Name = "Science Fiction", Description = "Sci-Fi books", CreationDate = DateTime.UtcNow }
        );

        // Seed Books
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", IdAuthor = 1, IdGenre = 1, Synopsis = "First book of Harry Potter.", ISBN = "9780747532699", Edition = "1st", PublicationYear = 1997, CreationDate = DateTime.UtcNow },
            new Book { Id = 2, Title = "A Game of Thrones", IdAuthor = 2, IdGenre = 1, Synopsis = "First book of A Song of Ice and Fire.", ISBN = "9780553103540", Edition = "1st", PublicationYear = 1996, CreationDate = DateTime.UtcNow }
        );
    }
}
